using AudioInsight.Application.Categories.Commands;
using AudioInsight.Domain;
using AutoMapper;

namespace AudioInsight.Application.Categories;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CreateNewCategoryCommand, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

        CreateMap<UpdateCategoryCommand, Category>();

        CreateMap<Category, Contracts.Models.Category>();
    }
}
