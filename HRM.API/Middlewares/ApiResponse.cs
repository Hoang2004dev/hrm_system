using System.Diagnostics;

namespace HRM.API.Middlewares
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public object? Errors { get; set; }
        public string? TraceId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Các hàm khởi tạo cho response thành công hoặc thất bại
        public static ApiResponse<T> Success(T data, string message = "Request successful", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = null,
                TraceId = Activity.Current?.Id ?? string.Empty
            };
        }

        public static ApiResponse<T> Failure(string message, object? errors = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = default,
                Errors = errors,
                TraceId = Activity.Current?.Id ?? string.Empty
            };
        }

        public static ApiResponse<T> NoContent(string message = "No content available")
        {
            return new ApiResponse<T>
            {
                StatusCode = 204,
                Message = message,
                Data = default,
                Errors = null,
                TraceId = Activity.Current?.Id ?? string.Empty
            };
        }
    }
}
