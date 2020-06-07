using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Core
{
    public class MentalHealthTestComponent : IMentalHealthTestComponent
    {
        private readonly IMentalHealthTestAdapter _mentalHealthTestAdapter;
        public MentalHealthTestComponent(IMentalHealthTestAdapter mentalHealthTestAdapter)
        {
            _mentalHealthTestAdapter = mentalHealthTestAdapter;
        }
        public async Task<Question> GetQuestion(Question question)
        {
            return await _mentalHealthTestAdapter.GetQuestion(question.TestType, question.QuestionId);
        }

        public async Task<Report> GetResult(Report result)
        {
            if (!await _mentalHealthTestAdapter.IsValidUser(result.UserId))
                throw ClientSideExceptions.InvalidUser();
            if(await _mentalHealthTestAdapter.GetReport(result.UserId, result.TestType, result.TestId) == null)
            {
                var scores = await _mentalHealthTestAdapter.GetScoresFromCache(result.UserId, result.TestType, result.TestId);
                result.Score = GetAverage(scores);
                if (result.Score == -1)
                    throw ClientSideExceptions.InvalidTest();
                if (await _mentalHealthTestAdapter.SaveResult(result))
                    await _mentalHealthTestAdapter.RemoveScoresFromCache(result.UserId, result.TestType, result.TestId);
            }
            var report = await _mentalHealthTestAdapter.GetReport(result.UserId, result.TestType, result.TestId);
            return await _mentalHealthTestAdapter.MapScoreWithDescription(report);
        }

        private double GetAverage(Dictionary<int, int> scores)
        {
            if (scores == null)
                return -1;
            double total = 0;
            scores?.ToList().ForEach(score =>
            {
                total += score.Value;
            });
            return total / (scores.Count);
        }

        public async Task<bool> SaveResponse(Answer answer)
        {
            if (!await _mentalHealthTestAdapter.IsValidUser(answer.UserId))
                throw ClientSideExceptions.InvalidUser();
            var score = await _mentalHealthTestAdapter.GetScoreOfOption(answer.TestType, answer.QuestionNumber, answer.ChosenOption);
            return await _mentalHealthTestAdapter.AddScoreToCache(answer.TestType, answer.UserId, answer.TestId, answer.QuestionNumber, score);
        }
    }
}
