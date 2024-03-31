using Domain.Categories;
using Domain.Categories.ValueObjects;

namespace Application.Base.Repositories;

public interface ICategoryRepository
{
    Task<Category> Add(Category category);
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetByUrl(Url url);
}
