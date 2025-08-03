
using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class BadRequestException(
    string details = "The request could not be understood or was missing required parameters.",
    int errorCode = 400,
    string message = "Bad Request"
    ) : AppException(ErrorType.BAD_REQUEST, details, errorCode, message)
{
}