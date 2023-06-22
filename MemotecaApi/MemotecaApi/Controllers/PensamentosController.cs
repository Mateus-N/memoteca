using MemotecaApi.Core;
using MemotecaApi.Dtos;
using MemotecaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemotecaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PensamentosController : ControllerBase
{
    private readonly IPensamentoService service;
    private readonly ILogger<PensamentosController> logger;

    public PensamentosController(IPensamentoService service, ILogger<PensamentosController> logger)
    {
        this.service = service;
        this.logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            logger.LogDebug("Passando id para service");
            ReadPensamentoDto? pensamento = await service.BuscaPorIdAsync(id);
            if (pensamento != null)
            {
                logger.LogDebug("Retornando pensamento id={id}", id);
                return Ok(pensamento);
            }
        }
        catch (Exception ex)
        {
            logger.LogError("Erro ao buscar pensamento", ex);
            return StatusCode(500);
        }
        logger.LogWarning("Pensamento id={id} não encontrado", id);
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetALlPagedAsync([FromQuery] PagedBaseRequest request)
    {
        try
        {
            var pensamentosPaginados = await service.GetPagedAsync(request);
            return Ok(pensamentosPaginados);
        }
        catch (Exception ex)
        {
            logger.LogError("Erro ao buscar todos os pensamentos", ex);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePensamentoDto dto)
    {
        try
        {
            ReadPensamentoDto pensamento = await service.CriaPensamentoAsync(dto);
            return Created($"/api/pensamentos/{pensamento.Id}", pensamento);
        }
        catch (Exception)
        {
            logger.LogError("Erro ao criar pensamento");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdatePensamentoDto dto)
    {
        try
        {
            ReadPensamentoDto pensamento = await service.AtualizaPensamento(dto);
            if (pensamento !=  null) return Ok(pensamento);
        }
        catch (Exception ex)
        {
            logger.LogError("Erro ao atualizar pensamento", ex);
            return BadRequest();
        }
        logger.LogWarning("Pensamento não encontrado");
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await service.DeletaPensamentoAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("Erro ao apagar pensamento", ex);
            return StatusCode(500);
        }
    }
}
