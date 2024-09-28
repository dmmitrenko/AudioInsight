using AudioInsight.Domain;
using MediatR;

namespace AudioInsight.Application.Categories.Commands;

public record GetAllCategoriesCommand() : IRequest<List<Category>>;
