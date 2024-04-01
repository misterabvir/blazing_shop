using Microsoft.AspNetCore.Mvc;
using MediatR;

using Server.Common.Extensions;
using Server.Common.Endpoints;
using Application.Products.Queries.GetAll;
using Application.Products.Queries.GetById;
using Application.Products.Queries.GetByCategory;

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
}