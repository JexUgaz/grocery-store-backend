using grocery_store_backend.Config.Exceptions;
using grocery_store_backend.Data;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Domain.Enums;
using grocery_store_backend.Domain.Models;
using grocery_store_backend.Infraestructure.Dtos.Orders;
using Microsoft.EntityFrameworkCore;
namespace grocery_store_backend.Infraestructure.Services;

public class OrderService(AppDbContext context) : IOrderService
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> CreateOrder(CreateOrderDto dto)
    {
        if (dto.Items == null || dto.Items.Count == 0) throw new BadRequestException("Order must have at least one item.");

        var productIds = dto.Items.Select(i => i.ProductId).ToList();

        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id);

        decimal totalAmount = 0;
        var orderItems = new List<OrderItem>();

        foreach (var item in dto.Items)
        {
            if (!products.TryGetValue(item.ProductId, out var product))
            {
                throw new NotFoundException($"Product with ID {item.ProductId} does not exist.");
            }

            if (product.Stock < item.Quantity)
            {
                throw new InsufficientStockException(product.Name, product.Stock, item.Quantity);
            }

            var unitPrice = product.CurrentPrice;

            totalAmount += unitPrice * item.Quantity;

            orderItems.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                UnitPrice = unitPrice,
                Quantity = item.Quantity
            });

            product.Stock -= item.Quantity;
        }


        var order = new Order
        {
            Id = Guid.NewGuid(),
            ClientName = dto.ClientName,
            ClientEmail = dto.ClientEmail,
            ClientPhone = dto.ClientPhone,
            ClientAddress = dto.ClientAddress,
            ClientCity = dto.ClientCity,
            ClientReference = dto.ClientReference,
            TotalAmount = totalAmount,
            Status = OrderStatus.Paid,
            Currency = "USD",
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order.Id;
    }
}
