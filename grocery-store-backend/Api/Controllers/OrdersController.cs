using grocery_store_backend.Domain.Api;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Infraestructure.Dtos.Orders;
using Microsoft.AspNetCore.Mvc;

namespace grocery_store_backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService service) : ControllerBase
{
    private readonly IOrderService _service = service;

    [HttpPost]
    public async Task<IActionResult> CompleteOrder([FromBody] CreateOrderDto dto)
    {
        var id = await _service.CreateOrder(dto);
        return Ok(ApiResponse<Guid>.Success("Order was completed successfully", id));
    }
}
