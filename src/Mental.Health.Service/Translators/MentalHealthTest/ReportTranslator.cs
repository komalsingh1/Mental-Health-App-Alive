namespace Mental.Health.Service
{
    public static class ReportTranslator
    {
        public static ResultResponse ToResultResponse(this Report result)
        {
            return result == null
                ? null
                : new ResultResponse()
                {
                    MoodImageUrl = result.MoodImageUrl,
                    Score = result.Score,
                    Description = result.Description,
                    Summary = result.Summary
                };
        }
    }
}
