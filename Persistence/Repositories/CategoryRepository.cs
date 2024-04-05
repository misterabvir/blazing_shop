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



    public async Task<IEnumerable<Category>> GetCategoriesByProduct(ProductId productId)
        => await _context
        .Categories
        .AsNoTracking()
        .Where(c => c.PublishVariants.Any(pv => pv.Items.Any(i => i.ProductId == productId)))
        .ToListAsync();

    public async Task<IEnumerable<Category>> GetCategoriesByIds(IEnumerable<CategoryId> ids)
        => await _context.Categories.AsNoTracking().IgnoreAutoIncludes().Where(c => ids.Contains(c.Id)).ToListAsync();

    public Task<Category?> GetById(CategoryId categoryId)
    {
        return _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<Category> Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task Update(Category category)
    {              
        _context.Categories.Update(category);    

        await _context.SaveChangesAsync();
    }
}
