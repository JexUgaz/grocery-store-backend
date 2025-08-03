using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Domain.Api;

public class ApiError
{
    public required ErrorType Type { get; set; }
    public required string Details { get; set; } = string.Empty;
    public required int Code { get; set; }
}
