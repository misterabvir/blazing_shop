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
        category.ToTable("categories", "common");
        category.HasKey(c => c.Id);
        category.Property(c => c.Id)
            .HasConversion(id => id.Value, value => CategoryId.Create(value))
            .HasColumnName("category_id")
            .ValueGeneratedNever();

        category.Property(c => c.Title).HasConversion(title => title.Value, value => Title.Create(value));
        category.Property(c => c.Icon).HasConversion(icon => icon.Value, value => Icon.Create(value));
        category.Property(c => c.Url).HasConversion(url => url.Value, value => Url.Create(value));

        category.HasData(
            Category.Create(Title.Create("Books"), Icon.Create("bi bi-book"), Url.Create("books")).Value!,
            Category.Create(Title.Create("Electronics"), Icon.Create("bi bi-camera"), Url.Create("electronics")).Value!,
            Category.Create(Title.Create("Video Games"), Icon.Create("bi bi-controller"), Url.Create("video-games")).Value!);
    }
}
