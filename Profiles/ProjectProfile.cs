using AutoMapper;
using Portifólio_DotNet.Dtos.Project;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<Project, ReadProjectDto>();
        CreateMap<UpdateProjectDto, Project>();
        CreateMap<Project, UpdateProjectDto>();
    }
}