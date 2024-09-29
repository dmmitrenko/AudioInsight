using AudioInsight.Application.Categories.Commands;
using AudioInsight.Infrastructure;
using AudioInsight.Infrastructure.Exceptions;
using AudioInsight.Infrastructure.Repositories;
using MediatR;

namespace AudioInsight.Application.Categories.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await _repository.IsEntityExists(c => c.Id == new Guid(request.categoryId));

        if (isCategoryExists)
        {
            throw new DomainException("This category was not found.", System.Net.HttpStatusCode.NotFound);
        }

        await _repository.Delete(new Guid(request.categoryId));
        return Unit.Value;
    }
}
