using Application.Categories.Commands.Create;
using Contracts.Categories;
using Domain.Categories;
using Domain.Categories.Entities;
using Shared.Results;

namespace Server.Common.Extensions;

public static class CategoryExtensions
{
    public static CategoryContract Map(this Category category) => new()
    {
        Id = category.Id.Value,
        Title = category.Title.Value,
        Icon = category.Icon.Value,
        Url = category.Url.Value,
        PublishVariants = category.PublishVariants.Select(v => v.Map()).ToList()
    };

    public static PublishVariantContract Map(this PublishVariant variant) => new()
    {
        Id = variant.Id.Value,
        Title = variant.Title.Value,
        Icon = variant.Icon.Value,
        Url = variant.Url.Value
    };

    public static CategoryCreateCommand Map(this CategoryCreateRequest request) 
        => new(
        request.Title,
        request.Icon,
        request.Url,
        request.PublishVariants.Select(v => v.Map()));

    public static CategoryPublishVariantItem Map(this PublishVariantCreateRequest request)
        => new(request.Title, request.Icon, request.Url);




    public static IEnumerable<CategoryContract> Map(this IEnumerable<Category> categories) => categories.ToList().ConvertAll(c => c.Map());

    public static Result<IEnumerable<CategoryContract>> Map(this Result<IEnumerable<Category>> result) => result.IsSuccess ? result.Value!.Map().ToList() : result.Errors;

    public static Result<CategoryContract> Map(this Result<Category> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;
}
