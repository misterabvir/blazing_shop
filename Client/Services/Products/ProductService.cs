using Client.Services.Requests;
using Client.Services.Sessions;
using Contracts.Products;
using Shared.Pagination;
using Shared.Results;

namespace Client.Services.Products;

public class ProductService(IRequestService requestService, ISessionStorage sessionStorage) : IProductService
{
    private readonly IRequestService _requestService = requestService;
    private readonly ISessionStorage _sessionStorage = sessionStorage;


    public Task<Result<Pagination<ProductResponse>>> GetProducts(int page = 1, int pageSize = 3) 
        => _requestService.GetAsync<Pagination<ProductResponse>>($"/products/page/{page}/page-size/{pageSize}");

    public Task<Result<Pagination<ProductResponse>>> GetProductsByVariant(Guid variantId, int page, int pageSize)
        => _requestService.GetAsync<Pagination<ProductResponse>>($"/products/variant/{variantId}/page/{page}/page-size/{pageSize}");
    

    public Task<Result<Pagination<ProductResponse>>> GetProductsByCategory(Guid categoryId, int page = 1, int pageSize = 3) 
        =>  _requestService.GetAsync<Pagination<ProductResponse>>($"/products/category/{categoryId}/page/{page}/page-size/{pageSize}");

    public Task<Result<ProductResponse>> GetProductById(Guid productId) 
        => _requestService.GetAsync<ProductResponse>($"/products/{productId}");

    public async Task<Result<ProductResponse>> UpdateProduct(ProductUpdateRequest request)
    {
       var token =  await _sessionStorage.GetItem<string>("token");
       return await _requestService.PutAsync<ProductResponse>($"/products/update/{request.Id}", request, token);
    }

    public async Task<Result> CreateProduct(ProductCreateRequest request)
    {
        var token = await _sessionStorage.GetItem<string>("token");
        return await _requestService.PostAsync("/products/create", request, token);
    }

   
}
