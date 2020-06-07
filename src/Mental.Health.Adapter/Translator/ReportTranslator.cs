namespace Mental.Health.Adapter
{
    public static class ReportTranslator
    {
        public static TestResult ToTestResult(this Report report)
        {
            return report == null
                ? null
                : new TestResult()
                {
                    TestId = report.TestId,
                    Score = report.Score
                };
        }
    }
}
