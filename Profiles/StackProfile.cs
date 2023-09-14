using AutoMapper;
using Portifólio_DotNet.Dtos.Stack;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Profiles;

public class StackProfile : Profile
{
    public StackProfile()
    {
        CreateMap<CreateStackDto, Stack>();
        CreateMap<UpdateStackDto, Stack>();
        CreateMap<Stack, ReadStackDto>();
        CreateMap<Stack, UpdateStackDto>();
    }
}