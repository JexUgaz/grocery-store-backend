using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Config.Exceptions;

public class MethodNotAllowedException(string httpMethod) : AppException(ErrorType.METHOD_NOT_ALLOWED, $"The HTTP method '{httpMethod}' is not allowed for this endpoint.", 405, "Method Not Allowed")
{
}