using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class NotFoundException(string details) : AppException(ErrorType.NOT_FOUND, details, 404, "Resource not found.")
{
}
