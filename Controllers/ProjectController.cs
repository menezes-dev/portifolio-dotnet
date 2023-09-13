using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Portifólio_DotNet.Contexts;
using Portifólio_DotNet.Dtos.Project;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private ProjectContext _context;
    private IMapper  _mapper;

    public ProjectController(ProjectContext projectContext, IMapper mapper)
    {
        _context = projectContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] CreateProjectDto data)
    {
        Project project = _mapper.Map<Project>(data);
        _context.Projects.Add(project);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetrieveProject), new {id = project.Id}, project);
    }

    [HttpGet]
    public IEnumerable<ReadProjectDto> ReadProjects()
    {
        return _mapper.Map<List<ReadProjectDto>>(_context.Projects.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RetrieveProject(int id)
    {
        var project = _context.Projects.FirstOrDefault(project => project.Id == id);
        var errorMessage = new { message = "O projeto não foi encontrado" };

        if(project == null) return NotFound(errorMessage);

        var retrievedProject = _mapper.Map<ReadProjectDto>(project);

        return Ok(retrievedProject);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateProject(int id, JsonPatchDocument<UpdateProjectDto> data)
    {   
        var errorMessage = new {message = "O projeto não foi encontrado!"};
        var project = _context.Projects.FirstOrDefault(project => project.Id == id);

        if(project == null) return NotFound(errorMessage);

        var updateProject = _mapper.Map<UpdateProjectDto>(project);

        data.ApplyTo(updateProject, ModelState);

        if(!TryValidateModel(updateProject)) return ValidationProblem(ModelState);

        _mapper.Map(updateProject, project);
        _context.SaveChanges();

        return Ok(CreatedAtAction(nameof(RetrieveProject), new {id = project.Id}, updateProject).Value);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        var project = _context.Projects.FirstOrDefault(project => project.Id == id);
        var errorMessage = new { message = "O projeto não foi encontrado!" };

        if(project == null) return NotFound(errorMessage);

        _context.Remove(project);
        _context.SaveChanges();

        return NoContent();
    }
}