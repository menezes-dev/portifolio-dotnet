using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Models;

public class Experience
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Cargo { get; set; }

    [Required]
    public string Empresa { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Periodo { get; set; }
}