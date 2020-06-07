using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public class MentalHealthTestAdapter : IMentalHealthTestAdapter
    {
        private IQuestionsManager _questionsManager;
        private IUserReportsManager _userReportsManager;
        private IUsersManager _usersManager;
        private IResultContentsManager _resultContentsManager;
        private Dictionary<TestType, Dictionary<(string UserId, string TestId), Dictionary<int, int>>> _cache;
        public MentalHealthTestAdapter(IQuestionsManager questionsManager = null,IUserReportsManager userReportsManager = null, IUsersManager usersManager = null , IResultContentsManager resultContentsManager = null)
        {
            _questionsManager = questionsManager;
            _userReportsManager = userReportsManager;
            _usersManager = usersManager;
            _resultContentsManager = resultContentsManager;
            if (RunningTestsCache.TestType_UserTest_Choices == null)
                RunningTestsCache.SetUp();
            _cache = RunningTestsCache.TestType_UserTest_Choices;
        }

        public Task<bool> AddScoreToCache(string testType, string userId, string testId, int questionNumber, int score)
        {
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            if (score == -1 || testTypeValue==TestType.Unknown)
                return Task.FromResult(false);
            Dictionary<int, int> scores;
            _cache[testTypeValue].TryGetValue((userId, testId), out scores);
            if (scores == null)
            {
                scores = new Dictionary<int, int>();
                lock(_cache)
                    _cache[testTypeValue].Add((userId, testId), scores);
            }
            //if (scores.ContainsKey(questionNumber))
            //    scores.Remove(questionNumber);
            //scores.Add(questionNumber, score);
            scores[questionNumber] = score;
            return Task.FromResult(true);
        }

        public Task<Question> GetQuestion(string testType, int questionId)
        {
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            var question = _questionsManager.GetQuestionByNumber(testTypeValue, questionId);
            return Task.FromResult(question.ToQuestion(testType));
        }

        public Task<Report> GetReport(string userId, string testType, string testId)
        {
            var userReport = _userReportsManager.GetUserReportByUserId(userId);
            TestResult result = null;
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            switch (testTypeValue)
            {
                case TestType.Anxiety:
                    result = userReport?.AnxietyReport?.Where(report => string.Equals(testId, report.TestId)).FirstOrDefault();
                    break;
                case TestType.Depression:
                    result = userReport?.DepressionReport?.Where(report => string.Equals(testId, report.TestId)).FirstOrDefault();
                    break;
                case TestType.Stress:
                    result = userReport?.StressReport?.Where(report => string.Equals(testId, report.TestId)).FirstOrDefault();
                    break;
            }
            return Task.FromResult(result.ToReport(userId,testType));
        }

        public Task<int> GetScoreOfOption(string testType, int questionNumber, int chosenOption)
        {
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            var question = _questionsManager.GetQuestionByNumber(testTypeValue, questionNumber);
            var optionScore = question?.Options
                                        ?.Where(option => option.Number == chosenOption).FirstOrDefault()
                                        ?.Point ?? -1;
            return Task.FromResult(optionScore);
        }

        public Task<Dictionary<int, int>> GetScoresFromCache(string userId, string testType, string testId)
        {
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            if (testTypeValue == TestType.Unknown)
                return null;
            Dictionary<int, int> scores;
            _cache[testTypeValue].TryGetValue((userId, testId), out scores);
            return Task.FromResult(scores);
        }

        public Task<bool> IsValidUser(string userId)
        {
            return Task.FromResult(_usersManager.IsValidUserId(userId));
        }

        public Task<Report> MapScoreWithDescription(Report report)
        {
            TestType testTypeValue;
            Enum.TryParse(report.TestType, out testTypeValue);
            var resultContent = _resultContentsManager.GetResultContentByScore(testTypeValue,(int) Math.Abs(report.Score));
            return GetReportWithContent(report, resultContent);
        }

        private Task<Report> GetReportWithContent(Report report, ResultContent resultContent)
        {
            report.MoodImageUrl = resultContent?.ImageUrl;
            report.Description = resultContent?.Description;
            report.Summary = resultContent?.Summary;
            return Task.FromResult(report);
        }

        public Task RemoveScoresFromCache(string userId, string testType, string testId)
        {
            TestType testTypeValue;
            Enum.TryParse(testType, out testTypeValue);
            if (testTypeValue != TestType.Unknown && _cache[testTypeValue].ContainsKey((userId, testId)))
            {
                _cache[testTypeValue].Remove((userId, testId));
            }
            return Task.CompletedTask;
        }

        public Task<bool> SaveResult(Report result)
        {
            TestType testTypeValue;
            Enum.TryParse(result.TestType, out testTypeValue);
            var isSuccessFul = _userReportsManager.AddUserTestResultToReport(result.UserId, testTypeValue, result.ToTestResult());
            return Task.FromResult(isSuccessFul);
        }
    }
}
