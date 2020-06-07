namespace Mental.Health.Service
{
    public static class ResultRequestTranslator
    {
        public static Report ToResult(this ResultRequest request, string testId)
        {
            return request == null
                ? null
                : new Report()
                {
                    UserId = request.UserId,
                    TestType = request.TestType,
                    TestId=testId
                };
        }
    }
}
