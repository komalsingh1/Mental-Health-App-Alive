using System.Linq;

namespace Mental.Health.Adapter
{
    public static class QuestionModelTranslator
    {
        public static Question ToQuestion(this QuestionModel question, string testType)
        {
            return question == null
                ? null
                : new Question()
                {
                    TestType = testType,
                    QuestionId = question.Number,
                    Statement = question.Question,
                    Options = question.Options?
                                    .Select(op => op.ToOption())
                                    .ToList()
                };
        }
    }
}
