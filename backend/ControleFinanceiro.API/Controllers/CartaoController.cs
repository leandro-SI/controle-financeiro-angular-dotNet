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
    public class CartaoController : ControllerBase
    {

        private readonly ICartaoService _cartaoService;
        private readonly IDespesaService _despesaService;

        public CartaoController(ICartaoService cartaoService, IDespesaService despesaService)
        {
            _cartaoService = cartaoService;
            _despesaService = despesaService;
        }

        [HttpGet("get-by-user/{userId}")]
        public async Task<IActionResult> GetPorIdUsuario(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Invalid Data");

            var cartoes = await _cartaoService.GetByUserId(userId);

            if (cartoes == null)
                return NotFound();

            return Ok(cartoes);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetPorId(long id)
        {
            var cartao = await _cartaoService.GetById(id);

            if (cartao == null)
                return NotFound();

            return Ok(cartao);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CartaoDTO cartaoDTO)
        {
            if (cartaoDTO == null)
                return BadRequest("Invalid Data");

            await _cartaoService.Create(cartaoDTO);

            return Ok(new
            {
                mensagem = $"Cartão número {cartaoDTO.Numero} criado com sucesso."
            });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CartaoDTO cartaoDTO)
        {
            if (cartaoDTO == null)
                return BadRequest("Invalid Data");

            if (id != cartaoDTO.Id)
                return BadRequest("Invalid Data");

            await _cartaoService.Update(cartaoDTO);

            return Ok( new
            {
                mensagem = $"Cartão número {cartaoDTO.Numero} atualizado com sucesso."
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var cartao = await _cartaoService.GetById(id);

            if (cartao == null)
                return NotFound();

            await _cartaoService.Delete(id);

            var despesas = await _despesaService.GetByCartaoId(cartao.Id);

            _despesaService.DeleteDespesas(despesas);

            return Ok(new
            {
                mensagem = $"Cartão número {cartao.Numero} excluido com sucesso."
            });
        }

        [HttpGet("filtrar/{nome}")]
        public async Task<IActionResult> Filtrar(string nome)
        {
            var cartoes = await _cartaoService.Filtrar(nome);

            if (cartoes == null)
                return NotFound();

            return Ok(cartoes);
        }

    }
}
