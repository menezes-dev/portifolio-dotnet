using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Dtos.Qualification;

public class CreateQualificationDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Instituicao { get; set; }

    [Required]
    public string Periodo { get; set; }
}