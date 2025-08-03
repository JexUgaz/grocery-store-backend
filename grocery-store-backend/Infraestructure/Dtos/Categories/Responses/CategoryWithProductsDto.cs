using grocery_store_backend.Infraestructure.Dtos.Products.Responses;

namespace grocery_store_backend.Infraestructure.Dtos.Categories.Responses;

public class CategoryWithProductsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public String Image { get; set; } = default!;

    public List<ProductDto> Products { get; set; } = [];
}
