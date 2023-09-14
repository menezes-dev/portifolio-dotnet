using AutoMapper;
using Portifólio_DotNet.Dtos.Qualification;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Profiles;

public class QualificationProfile : Profile
{
    public QualificationProfile()
    {
        CreateMap<CreateQualificationDto, Qualification>();
        CreateMap<UpdateQualificationDto, Qualification>();
        CreateMap<Qualification, ReadQualificationDto>();
        CreateMap<Qualification, UpdateQualificationDto>();
    }
}