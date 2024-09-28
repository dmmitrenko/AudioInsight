using MediatR;

namespace AudioInsight.Application.Categories.Commands;
public record DeleteCategoryCommand(string categoryId) : IRequest<Unit>;