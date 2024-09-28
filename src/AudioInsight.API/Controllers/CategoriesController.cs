using AudioInsight.Application.Categories.Commands;
using AudioInsight.Contracts.Models;
using AudioInsight.Contracts.Requests.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(GetAllCategoriesRequest.Route)]    
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Category>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetAllCategoriesCommand());
        return Ok(categories);
    }

    [HttpPost(CreateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var category = await _mediator.Send(new CreateNewCategoryCommand(request.title, request.points));
        return Ok(category);
    }

    [HttpPut(UpdateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateCategory([FromRoute(Name = "category_id")] string categoryId, [FromBody] UpdateCategoryRequest request)
    {
        var category = await _mediator.Send(new UpdateCategoryCommand(categoryId, request.title, request.points));
        return Ok(category);
    }

    [HttpDelete(DeleteCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory([FromRoute(Name = "category_id")] string categoryId)
    {
        await _mediator.Send(new DeleteCategoryCommand(categoryId));
        return Ok();
    }
}
