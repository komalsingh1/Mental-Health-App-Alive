using System.Collections.Generic;

namespace Mental.Health
{
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<ErrorInfo> Infos { get; set; }
        public Error(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public Error() { }
    }
}
