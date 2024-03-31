using Contracts;
using Shared.Results;

namespace Client.Services.Categories;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryContract>>> GetCategories();
    Task<Result<CategoryContract>> GetCategoryByUrl(string url);
    Task Create(CategoryContract category);
    Action<Result<CategoryContract>> OnCategoriesChangedEvent { get; set; }
}
