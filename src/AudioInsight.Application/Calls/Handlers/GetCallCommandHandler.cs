using AudioInsight.Application.Calls.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Repositories;
using MediatR;

namespace AudioInsight.Application.Calls.Handlers;

public class GetCallCommandHandler : IRequestHandler<GetCallCommand, Call>
{
    private readonly ICallRepository _repository;

    public GetCallCommandHandler(ICallRepository repository)
    {
        _repository = repository;
    }

    public Task<Call> Handle(GetCallCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
