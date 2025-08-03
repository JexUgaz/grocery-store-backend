using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class UnsupportedMediaTypeException(
    string details = "The request content type is not supported. Expected 'application/json'.",
    int errorCode = 415,
    string message = "Unsupported Media Type"
    ) : AppException(ErrorType.UNSUPPORTED_MEDIA_TYPE, details, errorCode, message)
{
}