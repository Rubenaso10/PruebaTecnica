using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ParteCinco.Middlewares 
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next; // Declaración de _next
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next; // Inicialización de _next
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Llamar al siguiente middleware en la cadena
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, ex.Message);

            // Set the response
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // retorna un mensaje genérico
            var result = new
            {
                Message = "An unexpected error occurred. Please try again later."
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
