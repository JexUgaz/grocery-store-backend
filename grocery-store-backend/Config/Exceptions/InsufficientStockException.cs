namespace grocery_store_backend.Config.Exceptions;

public class InsufficientStockException(string productName, int available, int requested)
    : BadRequestException(
        details: $"Not enough stock for product '{productName}'. Available: {available}, Requested: {requested}",
        errorCode: 400,
        message: $"Not enough stock for product '{productName}'. Available: {available}, Requested: {requested}"
    )
{
}