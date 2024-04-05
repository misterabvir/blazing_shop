using Contracts.Products;
using Shared.Pagination;
using Shared.Results;

namespace Client.Services.Products;

public interface IProductService
{
    Task<Result<Pagination<ProductResponse>>> GetProducts(int page = 1, int pageSize = 3);
    Task<Result<Pagination<ProductResponse>>> GetProductsByCategory(Guid categoryId, int page = 1, int pageSize = 3);
    Task<Result<ProductResponse>> GetProductById(Guid productId);
    Task<Result<ProductResponse>> UpdateProduct(ProductUpdateRequest request);
    Task<Result> CreateProduct(ProductCreateRequest request);
}
