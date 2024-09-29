using AudioInsight.Application.Categories.Commands;
using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Exceptions;
using AudioInsight.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace AudioInsight.Application.Categories.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await _repository.IsEntityExists(c => c.Id == new Guid(request.id));

        if (!isCategoryExists)
        {
            throw new DomainException("Category cannot be updated", System.Net.HttpStatusCode.UnprocessableEntity);
        }

        var updatedCategory = await _repository.Update(_mapper.Map<Category>(request));
        return updatedCategory;
    }
}
