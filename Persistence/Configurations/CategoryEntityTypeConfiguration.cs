using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.HasKey(c => c.Id);
        category.Property(c => c.Id)
            .HasColumnName("category_id")
            .HasConversion(id => id.Value, value => CategoryId.Create(value))
            .ValueGeneratedNever();

        category.Property(c => c.Title).HasConversion(title => title.Value, value => Title.Create(value));
        category.Property(c => c.Icon).HasConversion(icon => icon.Value, value => Icon.Create(value));
        category.Property(c => c.Url).HasConversion(url => url.Value, value => Url.Create(value));
    }
}
