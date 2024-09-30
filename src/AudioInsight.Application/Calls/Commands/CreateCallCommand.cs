using MediatR;

namespace AudioInsight.Application.Calls.Commands;

public record CreateCallCommand(Guid id, string name, string text, string emotionalTone, string location, List<string> categories) : IRequest;
