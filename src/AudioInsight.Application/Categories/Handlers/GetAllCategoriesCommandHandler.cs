using AudioInsight.Application.Categories.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Repositories;
using MediatR;

namespace AudioInsight.Application.Categories.Handlers;

public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategoriesCommand, List<Category>>
{
    private readonly ICategoryRepository _repository;

    public GetAllCategoriesCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAll();
        return categories.ToList();
    }
}
