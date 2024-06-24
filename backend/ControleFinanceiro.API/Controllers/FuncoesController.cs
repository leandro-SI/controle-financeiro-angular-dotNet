using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoService _funcaoService;

        public FuncoesController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Listar()
        {
            var funcoes = await _funcaoService.GetAll();

            if (funcoes == null)
                return NotFound();

            return Ok(funcoes);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var funcao = await _funcaoService.GetById(id);

            if (funcao == null)
                return NotFound();

            return Ok(funcao);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FuncaoDTO funcaoDTO)
        {
            if (funcaoDTO == null)
                return BadRequest("Invalid Data.");

            await _funcaoService.Adicionar(funcaoDTO);

            return Ok(new { mensagem = $"Função {funcaoDTO.Name} criada com sucesso." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FuncaoDTO funcaoDTO)
        {
            if (funcaoDTO == null)
                return BadRequest("Invalid Data.");

            if (id != funcaoDTO.Id)
                return BadRequest("Invalid Data.");

            await _funcaoService.Atualizar(funcaoDTO);

            return Ok(new { mensagem = $"Função {funcaoDTO.Name} atualizada com sucesso." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var funcao = await _funcaoService.GetById(id);

            if (funcao == null)
                return NotFound();

            await _funcaoService.Delete(funcao);

            return Ok(new { mensagem = $"Função {funcao.Name} deletada com sucesso." });
        }

        [HttpGet("filtrar/{nome}")]
        public async Task<IActionResult> Filtrar(string nome)
        {
            var funcoes = await _funcaoService.Filtrar(nome);

            if (funcoes == null)
                return NotFound();

            return Ok(funcoes);
        }

    }
}
