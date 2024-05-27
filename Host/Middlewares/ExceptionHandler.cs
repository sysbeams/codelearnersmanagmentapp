using Application.Exceptions;
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
            var statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = "An unknown error occurred.";
            var errorType = $"{nameof(Exception)}/{Guid.NewGuid().ToString()}";

            if (exception is ValidationException)
            {
                statusCode = HttpStatusCode.BadRequest;
                errorMessage = exception.Message;
                errorType = $"{nameof(ValidationException)}/{Guid.NewGuid().ToString()}";
            }
            else if (exception is UnauthorizedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                errorMessage = "Unauthorized access.";
                errorType = $"{nameof(UnauthorizedException)}/{Guid.NewGuid().ToString()}";
            }
            else if (exception is ForbiddenException)
            {
                statusCode = HttpStatusCode.Forbidden;
                errorMessage = "Access to the resource is forbidden.";
                errorType = $"{nameof(ForbiddenException)}/{Guid.NewGuid().ToString()}";
            }

            var response = new Dtos.ProblemDetails(errorMessage, "Error", errorType);

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
