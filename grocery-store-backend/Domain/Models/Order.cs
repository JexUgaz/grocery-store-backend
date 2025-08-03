using grocery_store_backend.Domain.Enums;

namespace grocery_store_backend.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = default!;
    public string ClientEmail { get; set; } = default!;
    public string ClientPhone { get; set; } = default!;
    public string ClientAddress { get; set; } = default!;
    public string ClientCity { get; set; } = default!;
    public string? ClientReference { get; set; }

    public string Currency { get; set; } = default!;

    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Paid;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<OrderItem> Items { get; set; } = [];
}
