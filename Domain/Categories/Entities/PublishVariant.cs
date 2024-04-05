using Domain.Base;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;

namespace Domain.Categories.Entities;

public class PublishVariant : Entity<PublishVariantId>
{
    private PublishVariant() { }

    private PublishVariant(PublishVariantId id, CategoryId categoryId, Title title, Icon icon, Url url)
    {
        Id = id;
        Title = title;
        Icon = icon;
        Url = url;
        CategoryId = categoryId;
    }

    public CategoryId CategoryId { get; private set; } = null!;
    public Title Title { get; private set; } = null!;
    public Icon Icon { get; private set; } = null!;
    public Url Url { get; private set; } = null!;
    private readonly List<PublishVariantItem> _items = [];
    public IReadOnlyList<PublishVariantItem> Items => _items.AsReadOnly();


    public void AddProductId(ProductId productId) => _items.Add(PublishVariantItem.Create(CategoryId, Id, productId));
    public void RemoveProductId(ProductId productId) => _items.RemoveAll(i=>i.ProductId == productId);
    public void ClearProductIds() => _items.Clear();

    public void Update(Title? title = null, Icon? icon = null, Url? url = null)
    {
        if (title is not null)
            Title = title;
        if (icon is not null)
            Icon = icon;
        if (url is not null)
            Url = url;
    }


    public static PublishVariant Create(CategoryId categoryId, Title title, Icon icon, Url url)
        => new(PublishVariantId.CreateUnique(), categoryId, title, icon, url);
}
