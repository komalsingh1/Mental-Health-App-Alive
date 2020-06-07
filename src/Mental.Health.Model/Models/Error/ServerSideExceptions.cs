using Mental.Health.Model.Models.Error;
using System;
using System.Net;

namespace Mental.Health
{
    public static partial class ServerSideExceptions
    {
        public static BaseException JsonReadingFailure()
        {
            return new BaseException(FaultCodes.JsonReadingFailure, FaultMessages.JsonReadingFailure, HttpStatusCode.InternalServerError);
        }

    }
}
