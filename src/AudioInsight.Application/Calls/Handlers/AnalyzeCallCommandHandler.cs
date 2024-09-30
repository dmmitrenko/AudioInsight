using AudioInsight.Application.Calls.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Repositories;
using MediatR;

namespace AudioInsight.Application.Calls.Handlers;

public class AnalyzeCallCommandHandler : IRequestHandler<AnalyzeCallCommand, Guid>
{
    private readonly ICallRepository _repository;
    private readonly Dispatcher _dispatcher;

    public AnalyzeCallCommandHandler(ICallRepository repository, Dispatcher dispatcher)
    {
        _repository = repository;
        _dispatcher = dispatcher;
    }

    public async Task<Guid> Handle(AnalyzeCallCommand request, CancellationToken cancellationToken)
    {
        var call = new Call
        {
            Id = Guid.NewGuid(),
            Status = Domain.Enums.CallStatus.Unprocessed,
        };

        await _repository.Add(call);
        _dispatcher.SendMessage("audio.processing.#", new Contracts.Queue.StartAudioAnalysis
        {
            Id = call.Id,
            AudioUrl = request.audioUrl,
        });

        return call.Id;
    }
}
