using AutoMapper;
using MemotecaApi.Core;
using MemotecaApi.Data.Repositorys;
using MemotecaApi.Dtos;
using MemotecaApi.Models;
using MemotecaApi.Pagination;
using MemotecaApi.services;

namespace MemotecaApi.Services;

public class PensamentoService : IPensamentoService, IInjetable
{
    private readonly IMapper mapper;
    private readonly IPensamentoRepository repository;

    public PensamentoService(IMapper mapper, IPensamentoRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<ReadPensamentoDto?> BuscaPorIdAsync(Guid id)
    {
        Pensamento? pensamento = await repository.BuscaPorIdAsync(id);
        if (pensamento == null) return null;
        return mapper.Map<ReadPensamentoDto>(pensamento);
    }

    public async Task<ReadPensamentoDto> CriaPensamentoAsync(CreatePensamentoDto dto)
    {
        Pensamento pensamento = mapper.Map<Pensamento>(dto);
        await repository.CriaPensamentoAsync(pensamento);
        return mapper.Map<ReadPensamentoDto>(pensamento);
    }

    public async Task DeletaPensamentoAsync(Guid id)
    {
        await repository.DeletaPensamentoAsync(id);
    }

    public async Task<PagedBaseResponseDto<ReadPensamentoDto>> GetPagedAsync(PagedBaseRequest pensamentoFilterDb)
    {
        PagedBaseResponse<Pensamento> response = await repository.BuscaPaginadoAsync(pensamentoFilterDb);

        PagedBaseResponseDto<ReadPensamentoDto> result = new(
            response.OrderBy,
            response.PageNumber,
            response.PageSize,
            response.TotalPages,
            response.TotalRegisters,
            response.Reverse,
            mapper.Map<List<ReadPensamentoDto>>(response.Data)
        );

        return result;
    }

    public async Task<ReadPensamentoDto> AtualizaPensamento(UpdatePensamentoDto dto)
    {
        Pensamento update = mapper.Map<Pensamento>(dto);
        Pensamento pensamento = await repository.AtualizaPensamento(update);
        return mapper.Map<ReadPensamentoDto>(pensamento);
    }
}
