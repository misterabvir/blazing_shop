using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.Entities;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.ToTable("products", "product_schema");
        product.HasKey(p => p.Id);
        product.Property(p => p.Id)
            .HasConversion(id => id.Value, value => ProductId.Create(value))
            .HasColumnName("product_id")
            .ValueGeneratedNever();

        product.Property(p => p.Title).HasConversion(title => title.Value, value => Title.Create(value));
        product.Property(p => p.Description).HasConversion(description => description.Value, value => Description.Create(value));
        product.Property(p => p.Image).HasConversion(image => image.Value, value => Image.Create(value));
        product.Property(p => p.CreatedAt).HasConversion(date => date.Value, value => Date.Create(value));
        product.Property(p => p.UpdatedAt).HasConversion(date => date.Value, value => Date.Create(value));
        product.Property(p => p.CategoryId).HasConversion(id => id.Value, value => CategoryId.Create(value));

        product.OwnsMany(p => p.Variants, VariantConfigure).UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void VariantConfigure(OwnedNavigationBuilder<Product, Variant> variant)
    {
        variant.ToTable("variants", "product_schema");
        variant.WithOwner().HasForeignKey(v=>v.ProductId);
        variant.HasKey(v => new {v.ProductId, v.Id});
        variant.Property(v => v.Id).HasConversion(id => id.Value, value => VariantId.Create(value)).HasColumnName("variant_id");
        variant.Property(v => v.PublishVariantId).HasConversion(id => id.Value, value => PublishVariantId.Create(value));
        variant.Property(v => v.ProductId).HasConversion(id => id.Value, value => ProductId.Create(value));
        variant.Property(v => v.Price).HasConversion(price => price.Value, value => Price.Create(value));
        variant.Property(v => v.Discount).HasConversion(discount => discount.Value, value => Discount.Create(value));
    }
}
