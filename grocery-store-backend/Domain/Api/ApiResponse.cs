using grocery_store_backend.Config.Exceptions;
using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Domain.Api;


public class ApiResponse<T>
{
    public required string Message { get; set; }
    public required ApiResponseStatus Status { get; set; }
    public T? Data { get; set; }
    public ApiError? Error { get; set; }

    public static ApiResponse<T> Success(string message, T data) => new()
    {
        Message = message,
        Status = ApiResponseStatus.SUCCESS,
        Data = data
    };

    public static ApiResponse<object> Exception(Exception exception)
    {
        AppException ex = exception switch
        {
            AppException e => e,
            Exception e => new InternalServerException(details: e.Message),
            _ => new InternalServerException(),
        };

        return new()
        {
            Message = ex.Message,
            Status = ApiResponseStatus.ERROR,
            Error = new ApiError
            {
                Type = ex.Type,
                Details = ex.Details,
                Code = ex.ErrorCode
            }
        };
    }


}
