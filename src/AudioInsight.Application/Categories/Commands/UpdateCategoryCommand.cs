using AudioInsight.Domain;
using MediatR;

namespace AudioInsight.Application.Categories.Commands;

public record UpdateCategoryCommand(string id, string title, List<string> points) : IRequest<Category>;
