
namespace grocery_store_backend.Domain.Models;

public class Category
{

    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public String Image { get; set; } = default!;

    public List<Product> Products { get; set; } = [];
}
