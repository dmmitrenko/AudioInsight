using AudioInsight.Application.Categories.Commands;
using AudioInsight.Domain;
using AudioInsight.Infrastructure;
using AudioInsight.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace AudioInsight.Application.Categories.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateNewCategoryCommand, Category>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(
        ICategoryRepository repository, 
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Category> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await _repository.IsCategoryExists(c => c.Title == request.title);
        
        if (isCategoryExists)
        {
            throw new DomainException("This category already exists", System.Net.HttpStatusCode.UnprocessableEntity);
        }

        var category = _mapper.Map<Category>(request);
        await _repository.Add(category);

        return category;
    }
}
