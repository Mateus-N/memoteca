using System.ComponentModel.DataAnnotations;

namespace MemotecaApi.Models;

public record Pensamento
{
    [Key]
    [Required]
    public required Guid Id { get; set; }
    [Required]
    public required string Conteudo { get; set; }
    [Required]
    public required string Autoria { get; set; }
    [Required]
    public required string Modelo { get; set; }
}
