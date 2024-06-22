using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUsuario(string id)
        {
            var usuario = await _usuarioService.GetById(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);

        }

        [HttpPost("save-foto")]
        public async Task<IActionResult> SalvarFoto()
        {
            var foto = Request.Form.Files[0];
            byte[] b;
            using (var openReadStream = foto.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    b = memoryStream.ToArray();
                }
            }

            return Ok(new { foto = b });
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegisterDTO registerDTO)
        {
            var usuarioDto = new UsuarioDTO
            {
                UserName = registerDTO.NomeUsuario,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Senha,
                CPF = registerDTO.CPF,
                Profissao = registerDTO.Profissao,
                Foto = registerDTO.Foto
            };

            string funcao = "Administrador";

            if (await _usuarioService.GetQuantidade() > 0)
                funcao = "Usuario";

            var usuarioCriado = await _usuarioService.CriarUsuario(usuarioDto, registerDTO.Senha);

            if (usuarioCriado.Succeeded)
            {
                usuarioDto.SecurityStamp = Guid.NewGuid().ToString();
                await _usuarioService.VincularUsuarioFuncao(usuarioDto, funcao);
                //await _usuarioService.LogarUsuario(usuarioDto, false);

                return Ok(new
                {
                    email = usuarioDto.Email,
                    usuarioId = usuarioDto.Id,
                    mensagem = "Usuário registrado com sucesso."
                });
            }

            return BadRequest(registerDTO);
        }

    }
}
