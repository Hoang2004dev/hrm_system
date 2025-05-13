using HRM.Application.Exceptions;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;

namespace HRM.API.Middlewares
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
                _logger.LogError(ex,"Exception caught in middleware: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            object? errors = null;
            string message = "An unexpected error occurred.";

            // Xử lý các loại lỗi cụ thể
            switch (exception)
            {
                case FluentValidation.ValidationException validation:
                    code = HttpStatusCode.BadRequest;
                    message = "Validation failed.";
                    errors = validation.Errors.Select(e => new
                    {
                        field = e.PropertyName,
                        error = e.ErrorMessage
                    });
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case ForbiddenAccessException:
                    code = HttpStatusCode.Forbidden;
                    message = exception.Message;
                    break;

                case UnauthorizedException:
                    code = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    break;

                case ConflictException:
                    code = HttpStatusCode.Conflict;
                    message = exception.Message;
                    break;

                case BadRequestException:
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
            }

            // Xử lý phản hồi trả về
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var response = ApiResponse<object>.Failure(message, errors, (int)code);
            response.TraceId = context.TraceIdentifier; // Gắn TraceId vào response

            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }

}
