using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Account;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
            _configuration = configuration;
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

            string funcao = "Administrador";

            if (await _usuarioService.GetQuantidade() > 0)
                funcao = "Usuario";

            var result = await _usuarioService.CriarUsuario(registerDTO, registerDTO.Senha);

            if (result)
            {
                var usuario = await _usuarioService.GetByEmail(registerDTO.Email);
                usuario.SecurityStamp = Guid.NewGuid().ToString();

                await _usuarioService.VincularUsuarioFuncao(usuario, funcao);

                //var tokenUsuario = TokenService.GerarToken(usuario.UserName, funcao, _configuration["Jwt:SecretKey"]);
                //var tokenUsuario = GerarToken(usuario, funcao, _configuration["Jwt:SecretKey"]);

                await _usuarioService.LogarUsuario(usuario, false);

                return Ok(new
                {
                    email = usuario.Email,
                    usuarioId = usuario.Id,
                    token = string.Empty,
                    mensagem = "Usuário registrado com sucesso."
                });
            }

            return BadRequest(registerDTO);
        }

        [HttpPost("logar")]
        public async Task<IActionResult> Logar([FromBody] LoginDTO loginDto)
        {
            if (loginDto == null)
                return NotFound("Usuario ou senha inválidos.");

            var usuario = await _usuarioService.GetByEmail(loginDto.Email);

            if (usuario != null)
            {
                PasswordHasher<UsuarioDTO> passwordHasher = new PasswordHasher<UsuarioDTO>();
                if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, loginDto.Senha) != PasswordVerificationResult.Failed)
                {
                    var funcoesUsuario = await _usuarioService.GetFuncoes(usuario);

                    //var tokenUsuario = TokenService.GerarToken(usuario.UserName, funcoesUsuario.First(), _configuration["Jwt:SecretKey"]);
                    //var tokenUsuario = GerarToken(usuario, funcoesUsuario.First(), _configuration["Jwt:SecretKey"]);


                    await _usuarioService.LogarUsuario(usuario, false);

                    return Ok(new
                    {
                        email = usuario.Email,
                        usuarioId = usuario.Id,
                        token = string.Empty
                    });
                }
                return NotFound("Usuário inválido.");

            }

            return NotFound("Usuário inválido.");
        }


    }
}
