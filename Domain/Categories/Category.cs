using Domain.Base;
using Domain.Categories.Entities;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Shared.Results;

namespace Domain.Categories;

public class Category : AggregateRoot<CategoryId>
{
    public Title Title { get; private set; } = null!;
    public Icon Icon { get; private set; } = null!;
    public Url Url { get; private set; } = null!;
    private readonly List<PublishVariant> _publishVariants = [];
    public IReadOnlyCollection<PublishVariant> PublishVariants => _publishVariants.AsReadOnly();


    private Category() { }
    private Category(CategoryId id, Title title, Icon icon, Url url)
    {
        Id = id;
        Title = title;
        Icon = icon;
        Url = url;
    }

    public static Category Create(Title title, Icon icon, Url url)
    {
        var category = new Category(CategoryId.CreateUnique(), title, icon, url);

        return category;
    }

    public Result UpdateTitle(Title? title = null, Icon? icon = null, Url? url = null)
    {
        if (title != null)
        {
            Title = title;
        }
        if (icon != null)
        {
            Icon = icon;
        }
        if (url != null)
        {
            Url = url;
        }
        return Result.Success();
    }

    public Result AddPublishVariant(PublishVariant variant)
    {
        _publishVariants.Add(variant);
        return Result.Success();
    }

    public Result AddPublishVariants(IEnumerable<PublishVariant> variants)
    {
        _publishVariants.AddRange(variants);
        return Result.Success();
    }



    public void UpdateProductsInPublishVariants(ProductId productId, List<PublishVariantId> variantIds)
    {
        _publishVariants.ForEach(s => s.RemoveProductId(productId));
        _publishVariants.Where(v => variantIds.Contains(v.Id)).ToList().ForEach(s => s.AddProductId(productId));
    }


    public Result RemoveProductIdInVariants(ProductId productId)
    {
        _publishVariants.ForEach(s => s.RemoveProductId(productId));
        return Result.Success();
    }
    public Result AddProductIdInVariants(ProductId productId, List<PublishVariantId> variantIds)
    {
        _publishVariants.Where(v => variantIds.Contains(v.Id)).ToList().ForEach(s => s.AddProductId(productId));
        return Result.Success();
    }


    public int CountVariants() => _publishVariants.Count;
    public int ProductIdsCount => _publishVariants.Sum(x => x.Items.Count);
}