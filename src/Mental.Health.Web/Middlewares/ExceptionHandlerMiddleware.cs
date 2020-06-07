using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mental.Health.Model.Models.Error;
namespace Mental.Health.Web.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(Exception exception)
            {
                await HandleException(exception, httpContext);
            }
        }

        public async Task HandleException(Exception exception, HttpContext context)
        {
            var appException = exception as BaseException;
            Error error;
            if (appException != null)
            {
                context.Response.StatusCode = (int)appException.HttpStatusCode;
                error = GetError(appException); 
            }
            else
            {
                error = GetInternalServerError(exception);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));

        }

        private Error GetInternalServerError(Exception exception)
        {
            var error = GetInternalServerError();
            error.Infos = new List<ErrorInfo>() { new ErrorInfo() { ErrorMessage = exception?.Message } };
            return error;
        }

        private Error GetError(BaseException appException)
        {
            return appException == null
                ? GetInternalServerError()
                : new Error(appException.ErrorCode, appException.ErrorMessage) { Infos = appException.Infos };
        }

        private Error GetInternalServerError()
        {
            return new Error(Int32.Parse(FaultCodes.UnexpectedError), FaultMessages.UnexpectedError);
        }
    }
}
