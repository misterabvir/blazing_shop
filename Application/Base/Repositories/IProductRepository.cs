using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.ValueObjects;
using Shared.Pagination;

namespace Application.Base.Repositories;

public interface IProductRepository
{
    Task<Pagination<Product>> GetAll(int take, int skip);
    Task<Pagination<Product>> GetByCategory(CategoryId categoryId, int page, int pageSize);
    Task<Pagination<Product>> GetByVariant(PublishVariantId variantId, int page, int pageSize);
    Task<Product?> GetById(ProductId productId);
    Task Add(Product product);
    Task Update(Product product);
}
