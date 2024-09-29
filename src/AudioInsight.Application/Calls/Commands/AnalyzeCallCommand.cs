using MediatR;

namespace AudioInsight.Application.Calls.Commands;

public record AnalyzeCallCommand(string audioUrl) : IRequest<Guid>;