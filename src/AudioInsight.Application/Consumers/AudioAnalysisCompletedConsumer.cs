using AudioInsight.Application.Calls.Commands;
using AudioInsight.Contracts.Queue;
using AudioInsight.Infrastructure.Exceptions;
using AudioInsight.Infrastructure.Queue;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AudioInsight.Application.Consumers;

public class AudioAnalysisCompletedConsumer : IMessageConsumer
{
    private readonly ILogger<AudioAnalysisCompletedConsumer> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AudioAnalysisCompletedConsumer(
        ILogger<AudioAnalysisCompletedConsumer> logger,
        IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public string RoutingKey => "audio.result";

    public async Task Consume(string message)
    {
        _logger.LogInformation($"Processing message: {message}");

        try
        {
            var call = JsonConvert.DeserializeObject<AudioAnalysisCompleted>(message);
            var command = _mapper.Map<CreateCallCommand>(call);
            await _mediator.Send(command);
        }
        catch (JsonException ex)
        {
            _logger.LogError($"Error deserializing message: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new DomainException($"Error during {nameof(AudioAnalysisCompleted)} processing.", System.Net.HttpStatusCode.InternalServerError, ex);
        }
    }
}
