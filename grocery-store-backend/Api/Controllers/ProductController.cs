using grocery_store_backend.Api.Filters;
using grocery_store_backend.Domain.Api;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Infraestructure.Dtos.Products.Requests;
using grocery_store_backend.Infraestructure.Dtos.Products.Responses;
using Microsoft.AspNetCore.Mvc;

namespace grocery_store_backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModel]
public class ProductController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;

    [HttpPost("by-ids")]
    public async Task<IActionResult> GetByIds([FromBody] ProductsByIdsDto body)
    {
        var results = await _service.GetByIds(body);
        return Ok(ApiResponse<List<ProductWithCategoryDto>>.Success("Products by Id retrieved successfully", results));
    }
}
