using MediatR;

namespace AudioInsight.Application.Calls.Commands;

public record CreateCallCommand(string name, string text, string emotionalTone, string location, List<string> categories) : IRequest;
