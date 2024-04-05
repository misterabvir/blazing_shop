using Domain.Base;
using Domain.Categories.ValueObjects;
using Domain.Products.Entities;
using Domain.Products.Events;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Shared.Results;

namespace Domain.Products;

public class Product : AggregateRoot<ProductId>
{
    public Title Title { get; private set; } = null!;
    public Description Description { get; private set; } = null!;
    public Image Image { get; private set; } = null!;
    public Date CreatedAt { get; private set; } = null!;
    public Date UpdatedAt { get; private set; } = null!;
    public CategoryId CategoryId { get; private set; } = null!;
    private readonly List<Variant> _variants = [];
    public IReadOnlyList<Variant> Variants => _variants.AsReadOnly();

    private Product() { }

    private Product(ProductId id, CategoryId categoryId, Title title, Description description, Image image)
    {
        Id = id;
        Title = title;
        Description = description;
        Image = image;
        CreatedAt = Date.Now;
        UpdatedAt = Date.Now;
        CategoryId = categoryId;
    }

    public static Product Create(
        CategoryId categoryId,
        Title title,
        Description description,
        Image image)
    {
        var product = new Product(ProductId.CreateUnique(),
                categoryId,
                 title,
                 description,
                 image);

        return product;
    }

    public Result Update(Title? title = null, Description? description = null, Image? image = null)
    {
        if (title is not null)
        {
            Title = title;
        }

        if (description is not null)
        {
            Description = description;
        }

        if (image is not null)
        {
            Image = image;
        }

        UpdatedAt = Date.Now;
        return Result.Success();
    }

    public Result UpdateVariants(IEnumerable<Variant> variants)
    {
        _variants.Clear();  
        _variants.AddRange(variants);
        UpdatedAt = Date.Now;
        RaiseDomainEvent(new ProductVariantsChangedDomainEvent(Id, CategoryId, variants.Select(v => v.PublishVariantId).ToList()));
        return Result.Success();
    }

}
