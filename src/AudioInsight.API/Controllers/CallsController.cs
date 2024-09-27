using AudioInsight.Contracts.Requests.Calls;
using AudioInsight.Contracts.Responses.Calls;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CallsController : ControllerBase
{

    [HttpPost(CreateCallRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCallResponse))]    
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateNewCall([FromBody] CreateCallRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet(GetCallRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCallResponse))]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> GetCall()
    {
        throw new NotImplementedException();
    }
}
