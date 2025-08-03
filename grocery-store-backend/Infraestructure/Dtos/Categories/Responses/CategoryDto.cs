namespace grocery_store_backend.Infraestructure.Dtos.Categories.Responses;

public class CategoryDto
{
    public Guid Id { get; set; }
    public String Image { get; set; } = default!;
    public string Name { get; set; } = default!;
}
