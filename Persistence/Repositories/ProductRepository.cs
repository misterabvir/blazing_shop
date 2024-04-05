using Application.Base.Repositories;
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
        var count = await _context.Products.CountAsync();
        var skip = (page - 1) * pageSize;
        var take = pageSize;
        var items = await _context.Products.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        var pagination = new Pagination<Product>()
        {
            Count = count,
            Items = items,
            Page = page,
            PageSize = pageSize
        };

        return pagination;
    }

    public async Task<Pagination<Product>> GetByCategory(CategoryId categoryId, int page, int pageSize)
    {
       
        var query = _context.Products.AsNoTracking().Where(c => c.CategoryId == categoryId);
        var count = await query.CountAsync();

        var skip = (page - 1) * pageSize;
        var take = pageSize;
        var items = await query.Skip(skip).Take(take).ToListAsync();
        var pagination = new Pagination<Product>()
        {
            Count = count,
            Items = items,
            Page = page,
            PageSize = pageSize
        };

        return pagination;
    }

    public async Task<Product?> GetById(ProductId productId) =>
        await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);

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
}
