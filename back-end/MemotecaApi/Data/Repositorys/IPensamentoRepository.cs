using MemotecaApi.Core;
using MemotecaApi.Dtos;
using MemotecaApi.Models;
using MemotecaApi.Pagination;

namespace MemotecaApi.Data.Repositorys
{
    public interface IPensamentoRepository
    {
        Task<Pensamento?> BuscaPorIdAsync(Guid id);
        Task CriaPensamentoAsync(Pensamento dto);
        Task DeletaPensamentoAsync(Guid id);
        Task<PagedBaseResponse<Pensamento>> BuscaPaginadoAsync(PagedBaseRequest request);
        Task<Pensamento> AtualizaPensamento(Pensamento dto);
    }
}