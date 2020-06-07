namespace Mental.Health.Service
{
    public static class AnswerRequestTranslator
    {
        public static Answer ToAnswer(this AnswerRequest request, string testId)
        {
            return request == null
                ? null
                : new Answer()
                {
                    TestType = request.TestType,
                    UserId = request.UserId,
                    TestId=testId,
                    QuestionNumber = request.QuestionNumber,
                    ChosenOption = request.OptionNumber
                };
        }
    }
}
