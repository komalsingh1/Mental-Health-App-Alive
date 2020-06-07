using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public interface IQuestionsManager
    {
        List<QuestionModel> GetAllQuestions(TestType test);
        QuestionModel GetQuestionByNumber(TestType test, int number);
        AnalyzingQuestion GetQuestionById(string questionId);
        bool AddQuestion(TestType test, QuestionModel question);
        bool DeleteQuestion(TestType test, QuestionModel question);
        bool DeleteQuestionByNumber(TestType test,int number);
        bool UpdateQuestion(TestType test, QuestionModel question);
    }
}
