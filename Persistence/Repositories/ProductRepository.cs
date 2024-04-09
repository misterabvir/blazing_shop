using Application.Base.Repositories;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Shared.Pagination;
namespace Persistence.Repositories;

internal class ProductRepository(BlazingShopContext context) : IProductRepository
{
    private readonly BlazingShopContext _context = context;

    public async Task<Pagination<Product>> GetAll(int page, int pageSize)
    {
        var query = _context.Products.AsNoTracking();
        return await GetPagination(page, pageSize, query);
    }

    public async Task<Pagination<Product>> GetByCategory(CategoryId categoryId, int page, int pageSize)
    {
       
        var query = _context.Products.AsNoTracking().Where(c => c.CategoryId == categoryId);
        return await GetPagination(page, pageSize, query);
    }

    public async Task<Pagination<Product>> GetByVariant(PublishVariantId variantId, int page, int pageSize)
    {
        var query = _context.Products.AsNoTracking().Where(c => c.Variants.Any(v => v.PublishVariantId == variantId));
        return await GetPagination(page, pageSize, query);
    }

    public async Task<Product?> GetById(ProductId productId) =>
        await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }


    private static async Task<Pagination<Product>> GetPagination(int page, int pageSize, IQueryable<Product> query)
    {
        var count = await query.CountAsync();
        var skip = (page - 1) * pageSize;
        var take = pageSize;
        var items = await query.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        var pagination = new Pagination<Product>()
        {
            Count = count,
            Items = items,
            Page = page,
            PageSize = pageSize
        };

        return pagination;
    }
}
