using Domain.Categories;
using Domain.Categories.Entities;
using Domain.Categories.ValueObjects;
using Domain.Products.Entities;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.ToTable("categories", "category_schema");
        category.HasKey(c => c.Id);
        category.Property(c => c.Id)
            .HasConversion(id => id.Value, value => CategoryId.Create(value))
            .HasColumnName("category_id")
            .ValueGeneratedNever();

        category.Property(c => c.Title).HasConversion(title => title.Value, value => Title.Create(value));
        category.Property(c => c.Icon).HasConversion(icon => icon.Value, value => Icon.Create(value));
        category.Property(c => c.Url).HasConversion(url => url.Value, value => Url.Create(value));

        category.OwnsMany(c => c.PublishVariants, PublishVariantConfigure).UsePropertyAccessMode(PropertyAccessMode.Field);


    }

    private void PublishVariantConfigure(OwnedNavigationBuilder<Category, PublishVariant> variant)
    {
        variant.ToTable("publish_variants", "category_schema");
        variant.WithOwner().HasForeignKey(c => c.CategoryId);
        variant.HasKey(v => new { v.CategoryId, v.Id });
        variant.Property(v => v.Id).HasConversion(id => id.Value, value => PublishVariantId.Create(value)).HasColumnName("publish_variant_id");
        variant.Property(v => v.Title).HasConversion(title => title.Value, value => Title.Create(value));
        variant.Property(v => v.Icon).HasConversion(icon => icon.Value, value => Icon.Create(value));
        variant.Property(v => v.Url).HasConversion(url => url.Value, value => Url.Create(value));

        variant.OwnsMany(v => v.Items, PublishVariantConfigure).UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void PublishVariantConfigure(OwnedNavigationBuilder<PublishVariant, PublishVariantItem> item)
    {
        item.ToTable("publish_variant_items", "category_schema");
        item.WithOwner().HasForeignKey(v => new { v.CategoryId, v.PublishVariantId });
        item.HasKey(v => new { v.Id, v.CategoryId, v.PublishVariantId });
        item.Property(v => v.CategoryId).HasConversion(id => id.Value, value => CategoryId.Create(value)).HasColumnName("category_id");
        item.Property(v => v.PublishVariantId).HasConversion(id => id.Value, value => PublishVariantId.Create(value)).HasColumnName("publish_variant_id");
        item.Property(v => v.Id).HasConversion(id => id.Value, value => PublishVariantItemId.Create(value)).HasColumnName("publish_variant_item_id");
        item.Property(v => v.ProductId).HasConversion(id => id.Value, value => ProductId.Create(value)).HasColumnName("product_id");
    }

}
