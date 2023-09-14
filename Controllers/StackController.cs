using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Portifólio_DotNet.Contexts;
using Portifólio_DotNet.Dtos.Stack;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Controllers;

[ApiController]
[Route("[Controller]")]
public class StackController : ControllerBase
{
    public IMapper _mapper;
    public ProjectContext _context;

    public StackController(IMapper mapper, ProjectContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateStack(CreateStackDto data)
    {
        var stack = _mapper.Map<Stack>(data);
        _context.Stacks.Add(stack);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RetriveStack), new {id = stack.Id}, stack);
    }

    [HttpGet]
    public IEnumerable<ReadStackDto> ReadStacks()
    {
        return _mapper.Map<List<ReadStackDto>>(_context.Stacks.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RetriveStack(int id)
    {
        var stack = _context.Stacks.FirstOrDefault(stack => stack.Id == id);
        var errorMessage = new {message = "Stack não encontrada!"};

        if(stack == null) return NotFound(errorMessage);

        var retriviedStack = _mapper.Map<ReadStackDto>(stack);

        return Ok(retriviedStack);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateStack(JsonPatchDocument<UpdateStackDto> data, int id)
    {
        var stack = _context.Stacks.FirstOrDefault(stack => stack.Id == id);
        var errorMessage = new { message = "Stack não encontrada" };

        if(stack == null) return NotFound(errorMessage);

        var updateStack = _mapper.Map<UpdateStackDto>(stack);

        data.ApplyTo(updateStack, ModelState);

        if(!TryValidateModel(updateStack)) return ValidationProblem(ModelState);     

        _mapper.Map(updateStack, stack);
        _context.SaveChanges();

        return Ok(CreatedAtAction(nameof(RetriveStack), new {id = stack.Id}, stack).Value);   
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStack(int id)
    {
        var stack = _context.Stacks.FirstOrDefault(stack => stack.Id == id);
        var errorMessage = new { message = "Stack não encontrada" };

        if(stack == null) return NotFound(errorMessage);

        _context.Remove(stack);
        _context.SaveChanges();

        return NoContent();
    }
}