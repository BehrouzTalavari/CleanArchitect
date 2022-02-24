using Microsoft.AspNetCore.Http;
using Core.Utility.Exceptions;

using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using System.Linq;

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
            string message = "Internal Server Error";
            string messageId = httpContext.Response.StatusCode.ToString();
            string result = new ErrorDetails
            {
                Message = message,
                StatusCode = httpContext.Response.StatusCode,
                MessageId = messageId
            }.ToString();


            GetValidationException(httpContext, e, ref message, ref result, ref messageId);
            GetAuthException(httpContext, e, ref message, ref result, ref messageId);

            return httpContext.Response.WriteAsync(result);
        }
        private void GetAuthException(HttpContext httpContext, Exception e, ref string message, ref string result, ref string messageId)
        {
            if (e.GetType() == typeof(AuthException))
            {
                var exeption = (AuthException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                result = new ErrorDetails
                {
                    Message = exeption.Message,
                    StatusCode = httpContext.Response.StatusCode,
                    MessageId = exeption.MessageId
                }.ToString();
            }
        }

        private void GetValidationException(HttpContext httpContext, Exception e, ref string message, ref string result, ref string messageId)
        {
            if (e.GetType() == typeof(ValidationException))
            {
                var exeption = (ValidationException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                result = new ErrorDetails
                {
                    Message = exeption.Message,
                    StatusCode = httpContext.Response.StatusCode,
                    MessageId = exeption.Errors.FirstOrDefault().ErrorCode
                }.ToString();
            }
        }
    }
}
