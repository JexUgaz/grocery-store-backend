using grocery_store_backend.Infraestructure.Dtos.Products.Requests;
using grocery_store_backend.Infraestructure.Dtos.Products.Responses;

namespace grocery_store_backend.Domain.Contracts;

public interface IProductService
{
    Task<List<ProductWithCategoryDto>> GetByIds(ProductsByIdsDto request);
}
