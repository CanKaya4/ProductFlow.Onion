using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ProductFlow.OnionTest.Server.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Bir hata oluştu: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = HttpStatusCode.InternalServerError;
            object? responseErrors = null;
            string message = "Sunucu tarafında bir hata oluştu.";

            
            if (exception is ValidationException validationException)
            {
                statusCode = HttpStatusCode.BadRequest; 
                message = "Validasyon hataları oluştu.";
                responseErrors = validationException.Errors
                    .Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage });
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
                Errors = responseErrors,
                Detailed = exception.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}