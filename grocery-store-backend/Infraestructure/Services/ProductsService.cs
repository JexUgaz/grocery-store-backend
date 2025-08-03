using grocery_store_backend.Config.Exceptions;
using grocery_store_backend.Data;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Infraestructure.Dtos.Products.Requests;
using grocery_store_backend.Infraestructure.Dtos.Products.Responses;
using Microsoft.EntityFrameworkCore;

namespace grocery_store_backend.Infraestructure.Services;

public class ProductsService(AppDbContext context) : IProductService
{
    private readonly AppDbContext _context = context;

    public async Task<List<ProductWithCategoryDto>> GetByIds(ProductsByIdsDto request)
    {
        if (request.Ids == null || request.Ids.Count == 0) throw new BadRequestException("The 'ids' parameter must not be empty.");

        var products = await _context.Products
            .Where(p => request.Ids.Contains(p.Id) && p.IsActive)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .ToListAsync();

        var result = products.Select(p => new ProductWithCategoryDto
        {
            Id = p.Id,
            Name = p.Name,
            PriceOriginal = p.PriceOriginal,
            IsActive = p.IsActive,
            QuantityInfo = p.QuantityInfo,
            Stock = p.Stock,
            PriceOffer = p.PriceOffer,
            CurrentPrice = p.CurrentPrice,
            Category = new()
            {
                Id = p.Category.Id,
                Name = p.Category.Name,
                Image = p.Category.Image
            },
            CreatedAt = p.CreatedAt,
            Currency = p.Currency,
            Description = p.Description,
            Image = p.Images.FirstOrDefault(i => i.IsMain)?.Url
        }).ToList();

        return result;
    }
}
