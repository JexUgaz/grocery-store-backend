using System.ComponentModel.DataAnnotations.Schema;

namespace grocery_store_backend.Domain.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string QuantityInfo { get; set; } = default!;
    public string? Description { get; set; }

    public decimal PriceOriginal { get; set; }
    public decimal? PriceOffer { get; set; }

    public string Currency { get; set; } = "USD";

    public int Stock { get; set; } = 100;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public List<ProductImage> Images { get; set; } = [];

    public decimal CurrentPrice => PriceOffer ?? PriceOriginal;
}
