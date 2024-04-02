using Contracts.Products;
using Domain.Products;
using Shared.Pagination;
using Shared.Results;

namespace Server.Common.Extensions;

public static class ProductExtensions
{
    public static ProductContract Map(this Product product)
       => new()
       {
           Id = product.Id.Value,
           Title = product.Title.Value,
           Description = product.Description.Value,
           Image = product.Image.Value,
           Price = product.Price.Value,
           OriginalPrice = product.OriginalPrice.Value,
           CreatedAt = product.CreatedAt.Value,
           UpdatedAt = product.UpdatedAt.Value,
       };
    
    public static Pagination<ProductContract> Map(this Pagination<Product> pagination)
    => new()
    {
        Count = pagination.Count,
        Page = pagination.Page,
        PageSize = pagination.PageSize,
        Items = pagination.Items.Select(c => c.Map()).ToList()
    };

    public static List<ProductContract> Map(this IEnumerable<Product> products) => products.Select(p => p.Map()).ToList();

    public static Result<ProductContract> Map(this Result<Product> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;
    
    public static Result<Pagination<ProductContract>> Map(this Result<Pagination<Product>> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;

}

