using AudioInsight.Application.Calls.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Exceptions;
using AudioInsight.Infrastructure.Repositories;
using MediatR;
using System.Net;

namespace AudioInsight.Application.Calls.Handlers;

public class GetCallCommandHandler : IRequestHandler<GetCallCommand, Call>
{
    private readonly ICallRepository _repository;

    public GetCallCommandHandler(ICallRepository repository)
    {
        _repository = repository;
    }

    public async Task<Call> Handle(GetCallCommand request, CancellationToken cancellationToken)
    {
        var call = await _repository.Get(request.filter);

        if (call is null)
            throw new DomainException("No such call was found", HttpStatusCode.NotFound);

        if (call.Status == Domain.Enums.CallStatus.Unprocessed)
            throw new DomainException("The call has not been processed yet", HttpStatusCode.Accepted);

        return call;
    }
}
