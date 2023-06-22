using MemotecaApi.Core;
using MemotecaApi.Dtos;
using MemotecaApi.Pagination;

namespace MemotecaApi.Services
{
    public interface IPensamentoService
    {
        Task<ReadPensamentoDto?> BuscaPorIdAsync(Guid id);
        Task<ReadPensamentoDto> CriaPensamentoAsync(CreatePensamentoDto dto);
        Task DeletaPensamentoAsync(Guid id);
        Task<PagedBaseResponseDto<ReadPensamentoDto>> GetPagedAsync(PagedBaseRequest request);
        Task<ReadPensamentoDto> AtualizaPensamento(UpdatePensamentoDto dto);
    }
}