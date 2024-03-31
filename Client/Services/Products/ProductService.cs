using Client.Services.Requests;
using Contracts.Products;
using Shared.Pagination;
using Shared.Results;

namespace Client.Services.Products;

public class ProductService(IRequestService requestService) : IProductService
{
    private readonly IRequestService _requestService = requestService;
    public Task<Result<Pagination<ProductContract>>> GetProducts(int page = 1, int pageSize = 3) 
        => _requestService.GetAsync<Pagination<ProductContract>>($"/products/page/{page}/page-size/{pageSize}");

    public Task<Result<Pagination<ProductContract>>> GetProductsByCategory(Guid categoryId, int page = 1, int pageSize = 3) 
        =>  _requestService.GetAsync<Pagination<ProductContract>>($"/products/category/{categoryId}/page/{page}/page-size/{pageSize}");

    public Task<Result<ProductContract>> GetProductById(Guid productId) 
        => _requestService.GetAsync<ProductContract>($"/products/{productId}");
}
