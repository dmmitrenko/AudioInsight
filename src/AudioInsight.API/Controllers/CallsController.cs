using AudioInsight.Application.Calls.Commands;
using AudioInsight.Contracts.Models;
using AudioInsight.Contracts.Requests.Calls;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudioInsight.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CallsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CallsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(CreateCallRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CallId))]    
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateNewCall([FromBody] CreateCallRequest request)
    {
        var callId = await _mediator.Send(new CreateCallCommand(request.audioUrl));
        return Ok(callId);
    }

    [HttpGet(GetCallRequest.Route)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Call))]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> GetCall()
    {
        var call = await _mediator.Send(new GetCallRequest());
        return Ok(call);
    }
}
