using Contracts.Categories;
using Shared.Results;

namespace Client.Services.Categories;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryContract>>> GetCategories();
    Task<Result<CategoryContract>> GetCategoryByUrl(string url);
    Task Create(CategoryCreateRequest request);
    Action<Result<CategoryContract>> OnCategoriesChangedEvent { get; set; }
}
