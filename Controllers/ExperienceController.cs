using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Portifólio_DotNet.Contexts;
using Portifólio_DotNet.Dtos.Experience;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Controllers;

[ApiController]
[Route("[Controller]")]
public class ExperienceController : ControllerBase
{   
    public IMapper _mapper;
    public ProjectContext _context;

    public ExperienceController(IMapper mapper, ProjectContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateExperience(CreateExperienceDto data)
    {
        var experience = _mapper.Map<Experience>(data);
        _context.Add(experience);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RetriveExperience), new {id = experience.Id}, experience);
    }

    [HttpGet]
    public IEnumerable<ReadExperienceDto> ReadExperiences()
    {
        return _mapper.Map<List<ReadExperienceDto>>(_context.Experiences.ToList());
    } 

    [HttpGet("{id}")]
    public IActionResult RetriveExperience(int id)
    {
        var experience = _context.Experiences.FirstOrDefault(experience => experience.Id == id);
        var errorMessage = new { message = "Experiência não encontrada!" };

        if(experience == null) return NotFound(errorMessage);

        var retrievedExperience = _mapper.Map<ReadExperienceDto>(experience);

        return Ok(retrievedExperience);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateExperience(JsonPatchDocument<UpdateExperienceDto> data, int id)
    {
        var experience = _context.Experiences.FirstOrDefault(experience => experience.Id == id);
        var errorMessage = new { message = "Experiência não encontrada!" };

        if(experience == null) return NotFound(errorMessage);

        var updateExperience = _mapper.Map<UpdateExperienceDto>(experience);
        data.ApplyTo(updateExperience, ModelState);

        if(!TryValidateModel(updateExperience)) return ValidationProblem(ModelState);

        _mapper.Map(updateExperience, experience);
        _context.SaveChanges();

        return Ok(CreatedAtAction(nameof(RetriveExperience), new {id = experience.Id = id}, experience).Value);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteExperience(int id)
    {
        var experience = _context.Experiences.FirstOrDefault(experience => experience.Id == id);
        var errorMessage = new { message = "Experiência não encontrada" };

        if(experience == null) return NotFound(errorMessage);

        _context.Remove(experience);
        _context.SaveChanges();

        return NoContent();
    }
}