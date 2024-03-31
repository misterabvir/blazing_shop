using Contracts.Products;
using Shared.Pagination;
using Shared.Results;

namespace Client.Services.Products;

public interface IProductService
{
    Task<Result<Pagination<ProductContract>>> GetProducts(int page = 1, int pageSize = 3);
    Task<Result<Pagination<ProductContract>>> GetProductsByCategory(Guid categoryId, int page = 1, int pageSize = 3);
    Task<Result<ProductContract>> GetProductById(Guid productId);


}
