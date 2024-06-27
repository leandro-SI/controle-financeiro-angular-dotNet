using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpGet("get-by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Invalid Data");

            var despesas = await _despesaService.GetByUserId(userId);

            return Ok(despesas);

        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var despesa = await _despesaService.GetById(id);

            if (despesa == null)
                return NotFound();

            return Ok(despesa);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] DespesaDTO despesaDTO)
        {
            if (despesaDTO == null)
                return BadRequest("Invalid Data");

            await _despesaService.Create(despesaDTO);

            return Ok(new
            {
                mensagem = $"Despesa no valor de R$ {despesaDTO.Valor} criada com sucesso."
            });

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] DespesaDTO despesaDTO)
        {
            if (despesaDTO == null)
                return BadRequest("Invalid Data");

            if (id != despesaDTO.Id)
                return BadRequest("Invalid Data");

            await _despesaService.Update(despesaDTO);

            return Ok(new
            {
                mensagem = $"Despesa no valor de R$ {despesaDTO.Valor} atualizada com sucesso."
            });

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var despesa = await _despesaService.GetById(id);

            if (despesa == null)
                return NotFound();

            await _despesaService.Delete(id);

            return Ok(new
            {
                mensagem = $"Despesa no valor de R$ {despesa.Valor} excluida com sucesso."
            });

        }

        [HttpGet("filtrar/{nomeCategoria}")]
        public async Task<IActionResult> Filtrar(string nomeCategoria)
        {
            var tipo = "Despesa";

            var cartoes = await _despesaService.Filtrar(nomeCategoria, tipo);

            if (cartoes == null)
                return NotFound();

            return Ok(cartoes);
        }

    }
}
