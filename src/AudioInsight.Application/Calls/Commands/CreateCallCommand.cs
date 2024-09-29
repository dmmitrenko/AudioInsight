using MediatR;

namespace AudioInsight.Application.Calls.Commands;

public record CreateCallCommand(string audioUrl) : IRequest<Guid>;
