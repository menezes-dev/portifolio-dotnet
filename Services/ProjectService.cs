using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portifólio_DotNet.Contexts;
using Portifólio_DotNet.Dtos.Project;

namespace Portifólio_DotNet.Services;

public class ProjectService
{
    private ProjectContext _context;
    private IMapper  _mapper;

    private Object errorMessage;

    public ProjectService(IMapper mapper, ProjectContext context, object errorMessage)
    {
        _mapper = mapper;
        _context = context;
        this.errorMessage = new {message = "Projeto não encontrado!"};
    }

    public bool VerifyId (int id)
    {
        var project = _context.Projects.FirstOrDefault(project => project.Id == id);

        if(project == null) return false;

        return true;
    }

    public Object RetrieveProject(int id)
    {
        var verify = VerifyId(id);
        if(!verify) return errorMessage;

        var project = _context.Projects.FirstOrDefault(project => project.Id == id);
        var retrievedProject = _mapper.Map<ReadProjectDto>(project);

        return retrievedProject;
    }
}
