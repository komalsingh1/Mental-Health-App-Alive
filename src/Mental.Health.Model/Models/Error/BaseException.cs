using System;
using System.Collections.Generic;
using System.Net;

namespace Mental.Health
{
    public class BaseException:Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<ErrorInfo> Infos { get; set; }
        public BaseException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Infos = new List<ErrorInfo>();
        }
        public BaseException(int errorCode, string errorMessage, HttpStatusCode httpStatusCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
            Infos = new List<ErrorInfo>();
        }
        public BaseException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode)
        {
            ErrorCode = int.Parse(errorCode);
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
            Infos = new List<ErrorInfo>();
        }
    }
}
