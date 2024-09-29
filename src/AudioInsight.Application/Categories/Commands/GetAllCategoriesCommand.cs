using AudioInsight.Domain.Model;
using MediatR;

namespace AudioInsight.Application.Categories.Commands;

public record GetAllCategoriesCommand() : IRequest<List<Category>>;
