namespace Mental.Health.Adapter
{
    public interface IUserReportsManager
    {
        UserReport GetUserReportByUserId(string userId);
        bool AddUserTestResultToReport(string userId, TestType test, TestResult result);
        bool CreateNewUserReportByUserId(string userId);
        bool DeleteUserReportByUserId(string userId);
        bool CleanAllTestResultsByUserId(string userId);
        bool CleanTestResults(string userId, TestType test);
    }
}
