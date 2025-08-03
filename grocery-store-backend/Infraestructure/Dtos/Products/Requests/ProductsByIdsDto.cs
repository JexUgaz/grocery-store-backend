
using Microsoft.AspNetCore.Mvc;

namespace grocery_store_backend.Infraestructure.Dtos.Products.Requests;

public class ProductsByIdsDto
{
    [FromQuery(Name = "ids")]
    public List<Guid> Ids { get; set; } = [];
}
