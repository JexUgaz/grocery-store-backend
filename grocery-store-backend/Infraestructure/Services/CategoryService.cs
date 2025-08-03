using grocery_store_backend.Data;
using grocery_store_backend.Domain.Api;
using grocery_store_backend.Domain.Contracts;
using grocery_store_backend.Infraestructure.Dtos.Categories.Requests;
using grocery_store_backend.Infraestructure.Dtos.Categories.Responses;
using grocery_store_backend.Infraestructure.Dtos.Products.Responses;
using Microsoft.EntityFrameworkCore;

namespace grocery_store_backend.Infraestructure.Services;

public class CategoryService(AppDbContext context) : ICategoryService
{
    private readonly AppDbContext _context = context;

    private readonly int _maxProductsPerCategory = 30;
    public async Task<List<CategoryWithProductsDto>> GetWithProducts(CategoryWithProductsQueryParameter request)
    {
        var productsPerCategory = Math.Min(request.ProductsPerCategory, _maxProductsPerCategory);
        var query = _context.Categories
           .Include(c => c.Products)
               .ThenInclude(p => p.Images)
           .AsQueryable();

        var categories = await query.ToListAsync();

        var results = categories.Select(c => new CategoryWithProductsDto
        {
            Id = c.Id,
            Name = c.Name,
            Image = c.Image,
            Products = [.. c.Products
                    .Take(productsPerCategory)
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        PriceOriginal = p.PriceOriginal,
                        IsActive = p.IsActive,
                        QuantityInfo = p.QuantityInfo,
                        Stock = p.Stock,
                        CurrentPrice = p.CurrentPrice,
                        PriceOffer = p.PriceOffer,
                        CreatedAt = p.CreatedAt,
                        Currency = p.Currency,
                        Description = p.Description,
                        Image = p.Images.FirstOrDefault(img => img.IsMain)?.Url
                    })]
        }).ToList();

        return results;
    }
}
