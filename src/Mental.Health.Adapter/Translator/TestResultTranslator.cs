namespace Mental.Health.Adapter
{
    public static class TestResultTranslator
    {
        public static Report ToReport(this TestResult result, string userId, string testType)
        {
            return result == null
                ? null
                : new Report()
                {
                    TestId = result.TestId,
                    Score = result.Score,
                    UserId=userId,
                    TestType=testType
                };
        }
    }
}
