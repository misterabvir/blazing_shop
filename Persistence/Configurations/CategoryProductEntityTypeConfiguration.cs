using Domain.CategoriesProducts;
using Domain.CategoriesProducts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class CategoryProductEntityTypeConfiguration : IEntityTypeConfiguration<CategoryProduct>
{
    public void Configure(EntityTypeBuilder<CategoryProduct> categoryProduct)
    {
        categoryProduct.ToTable("categories_products", "common");
        categoryProduct.HasKey(c => c.Id);
        categoryProduct.Property(c => c.Id).HasConversion(id => id.Value, value => CategoryProductId.Create(value));

        categoryProduct.HasOne(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId);
        categoryProduct.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId);
    }
}
