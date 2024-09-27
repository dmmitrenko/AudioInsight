using AudioInsight.Contracts.Responses.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategory()
    {
        throw new NotImplementedException();
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCategoryResponse))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory()
    {
        throw new NotImplementedException();
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCategoryResponse))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateCategory()
    {
        throw new NotImplementedException();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory()
    {
        throw new NotImplementedException();
    }
}
