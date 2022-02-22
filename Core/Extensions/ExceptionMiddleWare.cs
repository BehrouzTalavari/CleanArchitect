using Microsoft.AspNetCore.Http;

using System;
using System.Net;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (System.Exception e)
            {
               await HandleExceptionAsync(context, e);
            }
        }
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message="Internal Server Error...";
            
            var result=new ErrorDetails
            {
                Message=message,
                StatusCode= httpContext.Response.StatusCode,

            }.ToString();

            return httpContext.Response.WriteAsync(result);
        }
    }
}
