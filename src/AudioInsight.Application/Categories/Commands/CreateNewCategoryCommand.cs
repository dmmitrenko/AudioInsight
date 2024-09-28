using AudioInsight.Domain;
using MediatR;

namespace AudioInsight.Application.Categories.Commands;

public record CreateNewCategoryCommand(string title, List<string> points) : IRequest<Category>;
