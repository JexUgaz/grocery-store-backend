using grocery_store_backend.Infraestructure.Dtos.Orders;

namespace grocery_store_backend.Domain.Contracts;

public interface IOrderService
{
    Task<Guid> CreateOrder(CreateOrderDto dto);
}
