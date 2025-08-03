using grocery_store_backend.Infraestructure.Dtos.Categories.Requests;
using grocery_store_backend.Infraestructure.Dtos.Categories.Responses;

namespace grocery_store_backend.Domain.Contracts;

public interface ICategoryService
{
    Task<List<CategoryWithProductsDto>> GetWithProducts(CategoryWithProductsQueryParameter request);
}
