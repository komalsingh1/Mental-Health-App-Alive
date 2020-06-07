using System.Linq;

namespace Mental.Health.Adapter
{
    public static class AnalyzingQuestionTranslator
    {
        public static Health.AnalyzingQuestion ToAnalyzingQuestionCore(this AnalyzingQuestion question)
        {
            return question == null
                ? null
                : new Health.AnalyzingQuestion()
                {
                    QuestionId = question.QuestionId,
                    Statement = question.Question,
                    Options = question.Options?
                                    .Select(op => op.ToOption())
                                    .ToList()
                };
        }
    }
}
