
namespace grocery_store_backend.Infraestructure.Dtos.Orders;

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

}
