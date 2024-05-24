using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            if(exception.GetType().Name == "ValidationException")
            {
                var response = new Dtos.ProblemDetails(exception.Message, "This exception occurs when we could not validate the request", $"{nameof(ValidationException)}/{Guid.NewGuid().ToString()}");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            else
            {
                var response = new Dtos.ProblemDetails(exception.Message, "Unknown Error", $"{nameof(Exception)}/{Guid.NewGuid().ToString()}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            

        }

    }
}
