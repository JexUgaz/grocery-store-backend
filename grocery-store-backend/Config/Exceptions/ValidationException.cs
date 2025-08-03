using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class ValidationException(string details) : AppException(ErrorType.VALIDATION, details, 400, details)
{
}
