using Domain.Base;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;

namespace Domain.Categories.Entities;

public class PublishVariantItem : Entity<PublishVariantItemId>
{
    private PublishVariantItem() { }

    private PublishVariantItem(PublishVariantItemId id, CategoryId categoryId, PublishVariantId publishVariantId, ProductId productId)
    {
        Id = id;
        CategoryId = categoryId;
        PublishVariantId = publishVariantId;
        ProductId = productId;
    }

    public CategoryId CategoryId { get; private set; } = null!;
    public PublishVariantId PublishVariantId { get; private set; } = null!;
    public ProductId ProductId { get; private set; } = null!;
    public static PublishVariantItem Create(CategoryId categoryId, PublishVariantId publishVariantId, ProductId productId)
    {
        return new(PublishVariantItemId.CreateUnique(), categoryId, publishVariantId, productId);
    }
}