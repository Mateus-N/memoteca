using MemotecaApi.Core;
using MemotecaApi.Models;
using MemotecaApi.Pagination;
using MemotecaApi.services;
using Microsoft.EntityFrameworkCore;

namespace MemotecaApi.Data.Repositorys;

public class PensamentoRepository : IPensamentoRepository, IInjetable
{
    private readonly AppDbContext context;

    public PensamentoRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Pensamento?> BuscaPorIdAsync(Guid id)
    {
        return await context.Pensamentos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CriaPensamentoAsync(Pensamento pensamento)
    {
        await context.Pensamentos.AddAsync(pensamento);
        context.SaveChanges();
    }

    public async Task DeletaPensamentoAsync(Guid id)
    {
        Pensamento? pensamento = await BuscaPorIdAsync(id);
        if (pensamento != null)
        {
            context.Remove(pensamento);
            context.SaveChanges();
        }
    }

    public async Task<PagedBaseResponse<Pensamento>> BuscaPaginadoAsync(PagedBaseRequest request)
    {
        IQueryable<Pensamento> pensamentos = context.Pensamentos.AsQueryable();
        if (!string.IsNullOrEmpty(request.Busca))
        {
            pensamentos = pensamentos
                .Where(p => p.Autoria.Contains(request.Busca) || p.Conteudo.Contains(request.Busca));
        }

        return await PagedBaseResponseHelper
            .GetResponseAsync<PagedBaseResponse<Pensamento>, Pensamento>(pensamentos, request);
    }

    public async Task<Pensamento> AtualizaPensamento(Pensamento update)
    {
        context.Pensamentos.Update(update);
        context.SaveChanges();
        return await BuscaPorIdAsync(update.Id);
    }
}
