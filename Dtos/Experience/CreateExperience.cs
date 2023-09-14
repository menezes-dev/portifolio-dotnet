using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Dtos.Experience;

public class CreateExperienceDto
{
    [Required]
    public string Cargo { get; set; }

    [Required]
    public string Empresa { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Periodo { get; set; }
}