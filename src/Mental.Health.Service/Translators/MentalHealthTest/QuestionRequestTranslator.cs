namespace Mental.Health.Service
{
    public static class QuestionRequestTranslator
    {
        public static Question ToQuestion(this QuestionRequest request)
        {
            return request == null
                ? null
                : new Question()
                {
                    TestType = request.TestType,
                    QuestionId = request.QuestionNumber
                };
        }
    }
}
