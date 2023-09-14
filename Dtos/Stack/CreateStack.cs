using System.ComponentModel.DataAnnotations;

namespace Portifólio_DotNet.Dtos.Stack;

public class CreateStackDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Imagem { get; set; }
}