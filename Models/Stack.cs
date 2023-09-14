using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Models;

public class Stack
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Imagem { get; set; }
}