namespace Mental.Health.Service.Analyze
{
    public static class AnalyzingQuestionTranslator
    {
        public static QuestionResponse ToQuestionResponse(this AnalyzingQuestion question)
        {
            return question == null
                ? new QuestionResponse()
                : new QuestionResponse()
                {
                    Question = question.Statement,
                    Options = question.Options.ToOptionsContract()
                };
        }
    }
}
