using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Account;
using ControleFinanceiro.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public AuthenticationController(ITokenService tokenService, IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _tokenService = tokenService;
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
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
                var usuario = await _authenticateService.GetByEmail(registerDTO.Email);
                usuario.SecurityStamp = Guid.NewGuid().ToString();

                await _authenticateService.VincularUsuarioFuncao(usuario, funcao);

                var tokenUsuario = _tokenService.GenerateToken(usuario, funcao);

                if (tokenUsuario == null)
                    return Unauthorized();

                return Ok(new
                {
                    email = usuario.Email,
                    usuarioId = usuario.Id,
                    token = tokenUsuario,
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

            var usuario = await _authenticateService.GetByEmail(loginDto.Email);

            if (usuario != null)
            {
                PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
                if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, loginDto.Senha) != PasswordVerificationResult.Failed)
                {
                    var funcoesUsuario = await _authenticateService.GetFuncoes(usuario);

                    var tokenUsuario = _tokenService.GenerateToken(usuario, funcoesUsuario.First());

                    return Ok(new
                    {
                        email = usuario.Email,
                        usuarioId = usuario.Id,
                        token = tokenUsuario
                    });
                }
                return NotFound("Usuário inválido.");

            }

            return NotFound("Usuário inválido.");
        }

    }
}
