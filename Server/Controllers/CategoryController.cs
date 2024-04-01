using Microsoft.AspNetCore.Mvc;
using MediatR;
using Server.Common.Extensions;
using Server.Common.Endpoints;
using Contracts.Categories;
using Application.Categories.Queries.GetAll;
using Application.Categories.Queries.GetByUrl;
using Application.Categories.Commands.Create;

namespace Server.Controllers;

[ApiController]
[Route(EndPoints.Category.Controller)]
public class CategoryController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet(EndPoints.Category.Get.All)]
    public async Task<IActionResult> GetAll()
    {
        var query = new CategoryGetAllQuery();
        var response = await _sender.Send(query);
        return response.Map().Match(Ok, BadRequest);       
    }

    [HttpGet(EndPoints.Category.Get.ByUrl)]
    public async Task<IActionResult> GetByUrl(string url)
    {
        var query = new CategoryGetByUrlQuery(url);
        var response = await _sender.Send(query);
        return response.Map().Match(Ok, BadRequest);
    }

    [HttpPost(EndPoints.Category.Post.Create)]
    public async Task<IActionResult> Create(CategoryContract category)
    {
        var command = new CategoryCreateCommand(category.Title, category.Icon, category.Url);
        var response = await _sender.Send(command);
        return response.Map().Match(Ok, BadRequest);
    }
}
