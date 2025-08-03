using grocery_store_backend.Infraestructure.Dtos.Categories.Responses;

namespace grocery_store_backend.Infraestructure.Dtos.Products.Responses;

public class ProductWithCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string QuantityInfo { get; set; } = default!;
    public string? Description { get; set; }

    public decimal PriceOriginal { get; set; }
    public decimal? PriceOffer { get; set; }

    public string Currency { get; set; } = default!;

    public int Stock { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryDto Category { get; set; } = default!;

    public string? Image { get; set; }
    public decimal CurrentPrice { get; set; }
}
