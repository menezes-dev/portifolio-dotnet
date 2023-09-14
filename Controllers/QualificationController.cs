using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Portifólio_DotNet.Contexts;
using Portifólio_DotNet.Dtos.Qualification;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Controllers;

[ApiController]
[Route("[Controller]")]
public class QualificationController : ControllerBase
{
    public IMapper _mapper;
    public ProjectContext _context;

    public QualificationController(IMapper mapper, ProjectContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateQualification(CreateQualificationDto data)
    {
        var qualification = _mapper.Map<Qualification>(data);

        _context.Qualifications.Add(qualification);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RetriveQualification), new {id = qualification.Id}, qualification);
    }

    [HttpGet]
    public IEnumerable<ReadQualificationDto> ReadQualifications()
    {
        return _mapper.Map<List<ReadQualificationDto>>(_context.Qualifications.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RetriveQualification(int id)
    {
        var qualification = _context.Qualifications.FirstOrDefault(qualification => qualification.Id == id);
        var errorMessage = new { message = "Qualificação não encontrada!" };

        if(qualification == null) return NotFound(errorMessage);

        var retriviedQualification = _mapper.Map<ReadQualificationDto>(qualification);

        return Ok(retriviedQualification);
    }
    
    [HttpPatch("{id}")]
    public IActionResult UpdateQualification(JsonPatchDocument<UpdateQualificationDto> data, int id)
    {
        var qualification = _context.Qualifications.FirstOrDefault(qualification => qualification.Id == id);
        var errorMessage = new { message = "Qualificação não encontrada!" };

        if(qualification == null) return NotFound(errorMessage);

        var updateQualification = _mapper.Map<UpdateQualificationDto>(qualification);

        data.ApplyTo(updateQualification, ModelState);

        if(!TryValidateModel(updateQualification)) return ValidationProblem(ModelState);

        _mapper.Map(updateQualification, qualification);
        _context.SaveChanges();

        return Ok(CreatedAtAction(nameof(RetriveQualification), new {id = qualification.Id}, qualification).Value);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteQualification(int id)
    {
        var qualification = _context.Qualifications.FirstOrDefault(qualification => qualification.Id == id);
        var errorMessage = new { message = "Qualificação não encontrada!" };

        if(qualification == null) return NotFound(errorMessage);

        _context.Remove(qualification);
        _context.SaveChanges();

        return NoContent();
    }
}