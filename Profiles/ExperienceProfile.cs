using AutoMapper;
using Portifólio_DotNet.Dtos.Experience;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Profiles;

public class ExperienceProfile : Profile
{
    public ExperienceProfile()
    {
        CreateMap<CreateExperienceDto, Experience>();
        CreateMap<UpdateExperienceDto, Experience>();
        CreateMap<Experience, ReadExperienceDto>();
        CreateMap<Experience, UpdateExperienceDto>();
    }
}