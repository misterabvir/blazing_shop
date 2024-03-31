using Domain.Base;
using Domain.Categories.Events;
using Domain.Categories.ValueObjects;
using Domain.Shared.ValueObjects;
using Shared.Results;

namespace Domain.Categories;

public class Category : Entity<CategoryId>
{
    public Title Title { get; private set; } = null!;
    public Icon Icon { get; private set; } = null!;
    public Url Url { get; private set; } = null!;

    private Category() { }
    private Category(CategoryId id, Title title,Icon icon, Url url)
    {
        Id = id;
        Title = title;
        Icon = icon;
        Url = url;
    }

    public static Result<Category> Create(Title title, Icon icon, Url url)
    {
        var category = new Category(CategoryId.CreateUnique(), title, icon, url);
        
        category.RaiseDomainEvent(new CategoryCreatedDomainEvent(
            category.Id.Value,
            category.Title.Value,
            category.Url.Value));

        return category;
    }

    public Result UpdateTitle(Title title)
    {
        if (Title != title)
        {
            Title = title;
            RaiseDomainEvent(new CategoryTitleUpdatedDomainEvent(Id.Value, Title.Value));
            return Result.Success();
        }
        return Error.BadRequest("Domain.Category.UpdateTitle", "Category has same title");
    }

    public Result UpdateUrl(Url url)
    {
        if (Url != url)
        {
            Url = url;
            RaiseDomainEvent(new CategoryUrlUpdatedDomainEvent(Id.Value, Url.Value));
        }
        return Error.BadRequest("Domain.Category.UpdateUrl", "Category has same url");
    }

    public Result UpdateIcon(Icon icon)
    {
        if (Icon != icon)
        {
            Icon = icon;
            RaiseDomainEvent(new CategoryIconUpdatedDomainEvent(Id.Value, Icon.Value));
        }
        return Error.BadRequest("Domain.Category.UpdateIcon", "Category has same icon");
    }
}