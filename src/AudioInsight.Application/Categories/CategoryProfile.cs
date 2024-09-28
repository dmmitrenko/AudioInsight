using AudioInsight.Application.Categories.Commands;
using AudioInsight.Domain;
using AutoMapper;

namespace AudioInsight.Application.Categories;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateNewCategoryCommand, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
            .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.points));
    }
}
