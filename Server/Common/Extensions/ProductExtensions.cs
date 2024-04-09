using Application.Products.Commands.ProductCreate;
using Application.Products.Commands.ProductUpdate;
using Contracts.Products;
using Domain.Categories;
using Domain.Products;
using Domain.Products.Entities;
using Shared.Pagination;
using Shared.Results;

namespace Server.Common.Extensions;

public static class ProductExtensions
{
    public static ProductCreateCommand Map(this ProductCreateRequest request)
    => new
        (
        request.CategoryId,
        request.Title,
        request.Description,
        request.Image,
        request.Variants.Select(v => v.Map()).ToList());


    public static ProductVariantCreateCommand Map(this ProductVariantCreateRequest request)
        => new(request.PublishVariantId, request.Price);

    public static ProductUpdateCommand Map(this ProductUpdateRequest request)
        => new(
        request.Id,
        request.Title,
        request.Description,
        request.Image,
        request.Variants.Select(v => v.Map()).ToList());

    public static ProductUpdateVariantCommand Map(this ProductVariantUpdateRequest request)
        => new(request.PublishVariantId, request.Price, request.Discount);


    public static ProductResponse Map(this Product product)
       => new()
       {
           Id = product.Id.Value,
           Title = product.Title.Value,
           CategoryId = product.CategoryId.Value,
           Description = product.Description.Value,
           Image = product.Image.Value,
           CreatedAt = product.CreatedAt.Value,
           UpdatedAt = product.UpdatedAt.Value,
           Variants = product.Variants.Select(v => v.Map()).ToList()
       };

    public static ProductVariantResponse Map(this Variant product)
   => new()
   {
       Id = product.Id.Value,
       Price = product.Price.Value,
       Discount = product.Discount.Value,
       PublishVariantId = product.PublishVariantId.Value
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

