using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriasService;

        public CategoriasController(ICategoriaService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriasService.GetAll();

            if (categorias == null)
                return NotFound();

            return Ok(categorias);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var categoria = await _categoriasService.GetById(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Invalid Data.");

            await _categoriasService.Create(categoriaDTO);

            return Ok(new { mensagem = $"Categoria {categoriaDTO.Nome} criada com sucesso." });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Invalid Data.");

            if (id != categoriaDTO.Id)
                return BadRequest("Invalid Data.");

            await _categoriasService.Update(categoriaDTO);

            return Ok( new { mensagem = $"Categoria {categoriaDTO.Nome} atualizada com sucesso." });
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var categoriaDto = await _categoriasService.GetById(id);

            if (categoriaDto == null)
                return NotFound();

            await _categoriasService.Delete(id);

            return Ok(new { mensagem = $"Categoria {categoriaDto.Nome} excluida com sucesso." });
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("filtrar/{nome}")]
        public async Task<IActionResult> Filtrar(string nome)
        {
            var categorias = await _categoriasService.Filtrar(nome);

            if (categorias == null)
                return NotFound();

            return Ok(categorias);
        }


    }
}
