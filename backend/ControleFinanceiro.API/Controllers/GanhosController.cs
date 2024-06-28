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
    public class GanhosController : ControllerBase
    {
        private readonly IGanhoService _ganhoService;

        public GanhosController(IGanhoService ganhoService)
        {
            _ganhoService = ganhoService;
        }

        [HttpGet("get-by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Invalid Data");

            var ganhos = await _ganhoService.GetByUserId(userId);

            return Ok(ganhos);

        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var ganho = await _ganhoService.GetById(id);

            if (ganho == null)
                return NotFound();

            return Ok(ganho);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] GanhoDTO ganhoDto)
        {
            if (ganhoDto == null)
                return BadRequest("Invalid Data");

            await _ganhoService.Create(ganhoDto);

            return Ok(new
            {
                mensagem = $"Ganho no valor de R$ {ganhoDto.Valor} criado com sucesso."
            });

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] GanhoDTO ganhoDto)
        {
            if (ganhoDto == null)
                return BadRequest("Invalid Data");

            if (id != ganhoDto.Id)
                return BadRequest("Invalid Data");

            await _ganhoService.Update(ganhoDto);

            return Ok(new
            {
                mensagem = $"Ganho no valor de R$ {ganhoDto.Valor} atualizado com sucesso."
            });

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ganho = await _ganhoService.GetById(id);

            if (ganho == null)
                return NotFound();

            await _ganhoService.Delete(id);

            return Ok(new
            {
                mensagem = $"Ganho no valor de R$ {ganho.Valor} excluido com sucesso."
            });

        }

        [HttpGet("filtrar/{nomeCategoria}")]
        public async Task<IActionResult> Filtrar(string nomeCategoria)
        {
            var tipo = "Ganho";

            var ganhos = await _ganhoService.Filtrar(nomeCategoria, tipo);

            if (ganhos == null)
                return NotFound();

            return Ok(ganhos);
        }
    }
}
