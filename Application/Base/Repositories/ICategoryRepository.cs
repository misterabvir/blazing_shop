using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;

namespace Application.Base.Repositories;

public interface ICategoryRepository
{
    Task<Category> Add(Category category);
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetByUrl(Url url);
    Task<IEnumerable<Category>> GetCategoriesByProduct(ProductId productId);
    Task<IEnumerable<Category>> GetCategoriesByIds(IEnumerable<CategoryId> ids);

}
