using Domain.Base;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;

namespace Domain.Products.Entities;

public class Variant : Entity<VariantId>
{
    private Variant() { }
    
    
    private Variant(VariantId variantId, ProductId productId, PublishVariantId publishVariantId, Price price)
    {
        Id = variantId;
        PublishVariantId = publishVariantId;    
        Price = price;
        Discount = Discount.None;
        ProductId = productId;  
    }
    
    public ProductId ProductId { get; private set; } = null!;
    public PublishVariantId PublishVariantId { get; private set; } = null!;
    public Price Price { get; private set; } = null!;
    public Discount Discount { get; private set; } = null!;

    public static Variant Create(PublishVariantId publishVariantId, ProductId productId, Price price)
        => new (VariantId.CreateUnique(), productId, publishVariantId, price);
}
