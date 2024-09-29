using AudioInsight.Application.Calls.Commands;
using AudioInsight.Contracts.Queue;
using AudioInsight.Domain.Model;
using AutoMapper;

namespace AudioInsight.Application.Calls;

public class CallsProfile : Profile
{
    public CallsProfile()
    {
        CreateMap<AudioAnalysisCompleted, CreateCallCommand>();
        CreateMap<CreateCallCommand, Call>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.Ignore());
    }
}
