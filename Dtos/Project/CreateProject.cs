using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Dtos.Project;

public class CreateProjectDto
{
    [Required]
    public string Capa { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public string Tags {get; set;}

    [Required]
    public string Deploy { get; set; }

    [Required]
    public string Code { get; set; }
}