using Microsoft.AspNetCore.Mvc;
using MediatR;
using Server.Common.Extensions;
using Server.Common.Endpoints;
using Application.Products.Queries.GetAll;
using Application.Products.Queries.GetById;
using Application.Products.Queries.GetByCategory;
using Contracts.Products;

namespace Server.Controllers;

[ApiController]
[Route(EndPoints.Products.Controller)]
public class ProductController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet(template: EndPoints.Products.Get.All)]
    public async Task<IActionResult> GetAll(int page, int pageSize)
    {
        var query = new ProductGetAllRequest(page, pageSize);
        var response = await _sender.Send(query);
        return response.Map().Match(Ok, BadRequest);
    }

    [HttpGet(template: EndPoints.Products.Get.ById)]
    public async Task<IActionResult> GetById(Guid productId)
    {
        var query = new ProductGetByIdRequest(productId);
        var response = await _sender.Send(query);
        var result = response.Map().Match(Ok, BadRequest);
        return result;
    }


    [HttpGet(template: EndPoints.Products.Get.ByCategory)]
    public async Task<IActionResult> GetByCategory(Guid categoryId, int page, int pageSize)
    {
        var query = new ProductGetByCategoryRequest(categoryId, page, pageSize);
        var response = await _sender.Send(query);
        return response.Map().Match(Ok, BadRequest);
    }

    [HttpPut(template: EndPoints.Products.Put.Update)]
    public async Task<IActionResult> Update(ProductUpdateRequest request)
    {
        var command = request.Map();
        var response = await _sender.Send(command);
        return response.Map().Match(Ok, BadRequest);
    }

    [HttpPost(template: EndPoints.Products.Post.Create)]
    public async Task<IActionResult> Create(ProductCreateRequest request)
    {
        var command = request.Map();
        var response = await _sender.Send(command);
        return response.Match(Ok, BadRequest);
    }
}