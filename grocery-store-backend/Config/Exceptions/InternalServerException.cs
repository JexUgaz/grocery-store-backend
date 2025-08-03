
using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class InternalServerException(
    string details = "An unexpected error occurred on the server.",
    int errorCode = 500,
    string message = "Internal Server Error"
    ) : AppException(ErrorType.INTERNAL_SERVER, details, errorCode, message)
{
}