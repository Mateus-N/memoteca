namespace MemotecaApi.Dtos;

public record ReadPensamentoDto
{
    public Guid Id { get; set; }
    public required string Conteudo { get; set; }
    public required string Autoria { get; set; }
    public required string Modelo { get; set; }
}
