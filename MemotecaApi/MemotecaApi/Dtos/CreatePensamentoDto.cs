namespace MemotecaApi.Dtos;

public record CreatePensamentoDto
{
    public required string Conteudo { get; set; }
    public required string Autoria { get; set; }
    public required string Modelo { get; set; }
}
