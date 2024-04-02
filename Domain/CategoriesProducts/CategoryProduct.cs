using Domain.Base;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.CategoriesProducts.ValueObjects;
using Domain.Products;
using Domain.Products.ValueObjects;

namespace Domain.CategoriesProducts;

public class CategoryProduct : Entity<CategoryProductId>
{
    private CategoryProduct() { }
    
    private CategoryProduct(CategoryProductId id, ProductId productId, CategoryId categoryId)
    {
        Id = id;
        ProductId = productId;
        CategoryId = categoryId;
    }

    public ProductId ProductId { get; private set; } = null!;
    public CategoryId CategoryId { get; private set; } = null!;

    public virtual Product? Product { get; private set; }
    public virtual Category? Category { get; private set; }

    public static CategoryProduct Create(ProductId productId, CategoryId categoryId)
        => new(CategoryProductId.CreateUnique(), productId, categoryId);
}
