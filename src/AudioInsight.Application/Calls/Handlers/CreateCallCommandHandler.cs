using AudioInsight.Application.Calls.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Exceptions;
using AudioInsight.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace AudioInsight.Application.Calls.Handlers;

public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand>
{
    private readonly ICallRepository _repository;
    private readonly IMapper _mapper;

    public CreateCallCommandHandler(ICallRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        var call = _mapper.Map<Call>(request);

        var isCallExists = await _repository.IsEntityExists(c => c.Id == call.Id);

        if (isCallExists)
        {
            throw new DomainException("Call not found.", System.Net.HttpStatusCode.NotFound);
        }

        call.Status = Domain.Enums.CallStatus.Processed;
        await _repository.Update(call);
    }
}
