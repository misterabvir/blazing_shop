using Application.Base.Repositories;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class CategoryRepository(BlazingShopContext context) : ICategoryRepository
{
    private readonly BlazingShopContext _context = context;
    public async Task<IEnumerable<Category>> GetAll()
    {

        return await _context.Categories.AsNoTracking().ToListAsync();
    }

    public Task<Category?> GetByUrl(Url url) =>
        _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Url == url);

    public async Task<Category> Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesByProduct(ProductId productId) 
        => await _context
        .Categories
        .AsNoTracking()
        .Where(c => c.Products.Any(p => p.Id == productId))
        .ToListAsync();

    public async Task<IEnumerable<Category>> GetCategoriesByIds(IEnumerable<CategoryId> ids) 
        => await _context.Categories.AsNoTracking().IgnoreAutoIncludes().Where(c => ids.Contains(c.Id)).ToListAsync();
}
