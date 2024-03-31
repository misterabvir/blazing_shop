using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.ToTable("products", "common");
        product.HasKey(p => p.Id);
        product.Property(p => p.Id)
            .HasColumnName("product_id")
            .HasConversion(id => id.Value, value => ProductId.Create(value))
            .ValueGeneratedNever();
        product.HasOne<Category>().WithMany().HasForeignKey(p => p.CategoryId);

        product.Property(p => p.Title).HasConversion(title => title.Value, value => Title.Create(value));
        product.Property(p => p.Description).HasConversion(description => description.Value, value => Description.Create(value));
        product.Property(p => p.Image).HasConversion(image => image.Value, value => Image.Create(value));
        product.Property(p => p.Price).HasConversion(price => price.Value, value => Price.Create(value));
        product.Property(p => p.OriginalPrice).HasConversion(price => price.Value, value => Price.Create(value));
        product.Property(p => p.CreatedAt).HasConversion(date => date.Value, value => Date.Create(value));
        product.Property(p => p.UpdatedAt).HasConversion(date => date.Value, value => Date.Create(value));
        product.Property(p => p.CategoryId).HasConversion(categoryId => categoryId.Value, value => CategoryId.Create(value));
    }
}
