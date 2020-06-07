using System;
using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Adapter
{
    public class QuestionsManager : IQuestionsManager
    {
        private static object _lockObj;
        private static List<QuestionModel> _anxietyQuestions;
        private static List<QuestionModel> _depressionQuestions;
        private static List<QuestionModel> _stressQuestions;
        private static List<AnalyzingQuestion> _analyzingQuestions;
        public QuestionsManager()
        {
            _anxietyQuestions = GetQuestionsFromFile(GetPath(TestType.Anxiety));
            _depressionQuestions = GetQuestionsFromFile(GetPath(TestType.Depression));
            _stressQuestions = GetQuestionsFromFile(GetPath(TestType.Stress));
            try
            {
                _analyzingQuestions = JsonFileHandler.ReadFile<AnalyzingQuestion>(KeyStore.FilePaths.Questions.Analyze) ?? new List<AnalyzingQuestion>();
            }
            catch { }
            _lockObj = new object();
        }

        private List<QuestionModel> GetQuestionsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<QuestionModel>(path)?? new List<QuestionModel>();
            }
            catch
            {
                return new List<QuestionModel>();
            }
        }

        public bool AddQuestion(TestType test, QuestionModel question)
        {
            var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
            if (existingQuestion != null || string.IsNullOrEmpty(question.Question))
                return false;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                questions.Add(question);
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public bool DeleteQuestion(TestType test, QuestionModel question)
        {
            var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
            if (existingQuestion == null)
                return true;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                try
                {
                    questions.Remove(existingQuestion);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public bool DeleteQuestionByNumber(TestType test, int number)
        {
            var existingQuestion = GetQuestionByNumber(test, number);
            if (existingQuestion == null)
                return true;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                try
                {
                    questions.Remove(existingQuestion);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public List<QuestionModel> GetAllQuestions(TestType test)
        {
            var questions = new List<QuestionModel>();
            switch (test)
            {
                case TestType.Anxiety:
                    questions = _anxietyQuestions;
                    break;
                case TestType.Depression:
                    questions = _depressionQuestions;
                    break;
                case TestType.Stress:
                    questions = _stressQuestions;
                    break;
            }
            return questions;
        }
        private string GetPath(TestType test)
        {
            var path = default(string);
            switch (test)
            {
                case TestType.Anxiety:
                    path = KeyStore.FilePaths.Questions.Anxiety;
                    break;
                case TestType.Depression:
                    path = KeyStore.FilePaths.Questions.Depression;
                    break;
                case TestType.Stress:
                    path = KeyStore.FilePaths.Questions.Stress;
                    break;
            }
            return path;
        }
        public QuestionModel GetQuestionByNumber(TestType test, int number)
        {
            var questions = GetAllQuestions(test);
            return questions.Where(question => question.Number == number).FirstOrDefault();
        }

        public bool UpdateQuestion(TestType test, QuestionModel question)
        {
            lock (_lockObj)
            {
                var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
                if (existingQuestion == null || string.IsNullOrEmpty(question.Question))
                    return false;
                existingQuestion.Question = question.Question;
                existingQuestion.Options = question.Options;
                return JsonFileHandler.WriteInFile(GetAllQuestions(test), GetPath(test));
            }
        }

        public AnalyzingQuestion GetQuestionById(string questionId)
        {
            return _analyzingQuestions.Where(question => string.Equals(question.QuestionId, questionId)).FirstOrDefault();
        }
    }
}
