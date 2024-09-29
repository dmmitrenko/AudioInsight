using AudioInsight.Domain.Model;
using MediatR;

namespace AudioInsight.Application.Categories.Commands;

public record CreateNewCategoryCommand(string title, List<string> points) : IRequest<Category>;
