using AudioInsight.Application.Categories.Commands;
using AudioInsight.Contracts.Models;
using AudioInsight.Contracts.Requests.Categories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(GetAllCategoriesRequest.Route)]    
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Category>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetAllCategoriesCommand());
        return Ok(_mapper.Map<List<Category>>(categories));
    }

    [HttpPost(CreateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var category = await _mediator.Send(new CreateNewCategoryCommand(request.title, request.points));
        return CreatedAtAction(nameof(GetAllCategories), _mapper.Map<Category>(category));
    }

    [HttpPut(UpdateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateCategory([FromRoute(Name = "category_id")] string categoryId, [FromBody] UpdateCategoryRequest request)
    {
        var category = await _mediator.Send(new UpdateCategoryCommand(categoryId, request.title, request.points));
        return Ok(_mapper.Map<Category>(category));
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
