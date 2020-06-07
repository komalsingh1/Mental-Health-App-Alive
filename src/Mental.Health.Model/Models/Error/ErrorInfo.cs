namespace Mental.Health
{
    public class ErrorInfo
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorInfo(string errorCode, string errorMessage)
        {
            ErrorCode = int.Parse(errorCode);
            ErrorMessage = errorMessage;
        }
        public ErrorInfo() { }
    }
}