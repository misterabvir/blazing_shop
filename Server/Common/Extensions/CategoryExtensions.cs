using Contracts.Categories;
using Domain.Categories;
using Shared.Results;

namespace Server.Common.Extensions;

public static class CategoryExtensions
{
    public static CategoryContract Map(this Category category) => new()
    {
        Id = category.Id.Value,
        Title = category.Title.Value,
        Icon = category.Icon.Value,
        Url = category.Url.Value
    };

    public static IEnumerable<CategoryContract> Map(this IEnumerable<Category> categories) => categories.ToList().ConvertAll(c => c.Map());

    public static Result<IEnumerable<CategoryContract>> Map(this Result<IEnumerable<Category>> result) => result.IsSuccess ? result.Value!.Map().ToList() : result.Errors;

    public static Result<CategoryContract> Map(this Result<Category> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;
}
