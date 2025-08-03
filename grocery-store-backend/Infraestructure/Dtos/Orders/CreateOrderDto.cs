namespace grocery_store_backend.Infraestructure.Dtos.Orders;

public class CreateOrderDto
{
    public string ClientName { get; set; } = default!;
    public string ClientEmail { get; set; } = default!;
    public string ClientPhone { get; set; } = default!;
    public string ClientAddress { get; set; } = default!;
    public string ClientCity { get; set; } = default!;
    public string? ClientReference { get; set; }

    public List<OrderItemDto> Items { get; set; } = [];
}
