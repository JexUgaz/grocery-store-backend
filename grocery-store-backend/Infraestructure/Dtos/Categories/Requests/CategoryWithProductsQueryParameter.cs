using Microsoft.AspNetCore.Mvc;

namespace grocery_store_backend.Infraestructure.Dtos.Categories.Requests;

public class CategoryWithProductsQueryParameter
{
    [FromQuery(Name = "perCategory")]
    public int ProductsPerCategory { get; set; } = 6;
}
