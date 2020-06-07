namespace Mental.Health.Service.Analyze
{
    public static class AnswerRequestTranslator
    {
        public static AnalyzingAnswer ToAnswer(this Analyzer.AnswerRequest request)
        {
            return request == null
                ? null
                : new AnalyzingAnswer()
                {
                    UserId = request.UserId,
                    ChosenOption = request.OptionNumber,
                    QuestionId=request.QuestionId
                };
        }
    }
}
