using Client.Services.Requests;
using Contracts;
using Shared.Results;

namespace Client.Services.Categories;

public class CategoryService(IRequestService requestService) : ICategoryService
{
    private readonly IRequestService _requestService = requestService;
    public Action<Result<CategoryContract>> OnCategoriesChangedEvent { get; set; } = delegate { };


    public async Task Create(CategoryContract category)
    {
        var result = await _requestService.PostAsync<CategoryContract>("/categories/create", category);
        OnCategoriesChangedEvent?.Invoke(result);
    }

    public Task<Result<IEnumerable<CategoryContract>>> GetCategories() 
        => _requestService.GetIEnumerableAsync<CategoryContract>("/categories");

    public Task<Result<CategoryContract>> GetCategoryByUrl(string url) 
        => _requestService.GetAsync<CategoryContract>($"/categories/by-url/{url}");
}
