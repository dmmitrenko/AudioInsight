using AudioInsight.Application.Calls.Commands;
using MediatR;

namespace AudioInsight.Application.Calls.Handlers;

public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand, Guid>
{
    private readonly Dispatcher _dispatcher;

    public CreateCallCommandHandler(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<Guid> Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        _dispatcher.SendMessage("audio.processing.#", request.audioUrl);
        return Guid.NewGuid();
    }
}
