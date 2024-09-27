using AudioInsight.Contracts.Models;
using AudioInsight.Contracts.Requests.Categories;
using AudioInsight.Contracts.Responses.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{

    [HttpGet(GetAllCategoriesRequest.Route)]    
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConversationTopic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    [HttpPost(CreateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConversationTopic))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut(UpdateCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConversationTopic))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete(DeleteCategoryRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory()
    {
        throw new NotImplementedException();
    }
}
