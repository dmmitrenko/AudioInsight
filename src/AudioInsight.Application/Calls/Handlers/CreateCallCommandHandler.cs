using AudioInsight.Application.Calls.Commands;
using MediatR;

namespace AudioInsight.Application.Calls.Handlers;

public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand, Guid>
{
    public Task<Guid> Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
