using Client.Services.Requests;
using Contracts.Products;
using Shared.Pagination;
using Shared.Results;

namespace Client.Services.Products;

public class ProductService(IRequestService requestService) : IProductService
{
    private readonly IRequestService _requestService = requestService;
    public Task<Result<Pagination<ProductResponse>>> GetProducts(int page = 1, int pageSize = 3) 
        => _requestService.GetAsync<Pagination<ProductResponse>>($"/products/page/{page}/page-size/{pageSize}");

    public Task<Result<Pagination<ProductResponse>>> GetProductsByCategory(Guid categoryId, int page = 1, int pageSize = 3) 
        =>  _requestService.GetAsync<Pagination<ProductResponse>>($"/products/category/{categoryId}/page/{page}/page-size/{pageSize}");

    public Task<Result<ProductResponse>> GetProductById(Guid productId) 
        => _requestService.GetAsync<ProductResponse>($"/products/{productId}");

    public Task<Result<ProductResponse>> UpdateProduct(ProductUpdateRequest request, string token)
     => _requestService.PutAsync<ProductResponse>($"/products/update/{request.Id}", request, token);
}
