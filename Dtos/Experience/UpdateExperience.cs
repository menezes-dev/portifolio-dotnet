using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Dtos.Experience;

public class UpdateExperienceDto
{
    public string? Cargo { get; set; }

    public string? Empresa { get; set; }

    public string? Cidade { get; set; }

    public string? Periodo { get; set; }
}