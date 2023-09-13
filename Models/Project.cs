using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Models;

public class Project
{
    [Key]
    [Required]
    public int Id { get; set; }

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
