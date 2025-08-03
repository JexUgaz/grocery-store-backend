using grocery_store_backend.Domain.Api;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Infraestructure.Dtos.Categories.Requests;
using grocery_store_backend.Infraestructure.Dtos.Categories.Responses;
using Microsoft.AspNetCore.Mvc;

namespace grocery_store_backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService service) : ControllerBase
{
    private readonly ICategoryService _service = service;

    [HttpGet("products-by-category")]
    public async Task<IActionResult> GetProductsByCategory([FromQuery] CategoryWithProductsQueryParameter request)
    {
        var results = await _service.GetWithProducts(request);
        return Ok(ApiResponse<List<CategoryWithProductsDto>>.Success("Categories with products retrieved successfully", results));
    }

}
