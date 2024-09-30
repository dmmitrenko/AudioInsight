using AudioInsight.Application.Calls.Commands;
using AudioInsight.Contracts.Queue;
using AudioInsight.Domain.Enums;
using AudioInsight.Domain.Model;
using AutoMapper;

namespace AudioInsight.Application.Calls;

public class CallsProfile : Profile
{
    public CallsProfile()
    {
        CreateMap<AudioAnalysisCompleted, CreateCallCommand>();
        CreateMap<CreateCallCommand, Call>()
            .ForMember(dest => dest.EmotionalTone, opt => opt.MapFrom(src => Enum.Parse(typeof(EmotionalTone), src.emotionalTone)))
            .ForMember(dest => dest.Status, opt => opt.Ignore());
    }
}
