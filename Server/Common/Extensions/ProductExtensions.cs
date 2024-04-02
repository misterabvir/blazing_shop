using Application.Products.Commands.ProductUpdate;
using Contracts.Products;
using Domain.Categories;
using Domain.Products;
using Shared.Pagination;
using Shared.Results;

namespace Server.Common.Extensions;

public static class ProductExtensions
{

    public static ProductUpdateCommand Map(this ProductUpdateRequest request)
    => new(    
        request.Id,
        request.Title,
        request.Description,
        request.Image,
        request.Price,
        request.CategoryIds);


    public static ProductResponse Map(this Product product)
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
           Categories = product.Categories.Select(c => c.Map()).ToList()!
       };
    
    public static Pagination<ProductResponse> Map(this Pagination<Product> pagination)
    => new()
    {
        Count = pagination.Count,
        Page = pagination.Page,
        PageSize = pagination.PageSize,
        Items = pagination.Items.Select(c => c.Map()).ToList()
    };

    public static List<ProductResponse> Map(this IEnumerable<Product> products) => products.Select(p => p.Map()).ToList();

    public static Result<ProductResponse> Map(this Result<Product> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;
    
    public static Result<Pagination<ProductResponse>> Map(this Result<Pagination<Product>> result) => result.IsSuccess ? result.Value!.Map() : result.Errors;

}

