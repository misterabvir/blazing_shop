using Client.Services.Requests;
using Client.Services.Sessions;
using Contracts.Categories;
using Shared.Results;

namespace Client.Services.Categories;

public class CategoryService(IRequestService requestService, ISessionStorage sessionStorage) : ICategoryService
{
    private readonly IRequestService _requestService = requestService;
    private readonly ISessionStorage _sessionStorage = sessionStorage;
    public Action<Result<CategoryContract>> OnCategoriesChangedEvent { get; set; } = delegate { };


    public async Task Create(CategoryCreateRequest request)
    {
        var token = await _sessionStorage.GetItem<string>("token");
        var result = await _requestService.PostAsync<CategoryContract>("/categories/create", request, token);
        OnCategoriesChangedEvent?.Invoke(result);
    }

    public Task<Result<IEnumerable<CategoryContract>>> GetCategories() 
        => _requestService.GetIEnumerableAsync<CategoryContract>("/categories");

    public Task<Result<CategoryContract>> GetCategoryByUrl(string url) 
        => _requestService.GetAsync<CategoryContract>($"/categories/by-url/{url}");
}
