﻿using ControleFinanceiro.Application.Dtos;
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

            var model = new UsuarioUpdateDTO
            {
                Id = usuario.Id,
                UserName = usuario.UserName,
                Email = usuario.Email,
                CPF = usuario.CPF,
                Profissao = usuario.Profissao,
                Foto = usuario.Foto
            };

            return Ok(model);

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

        [HttpGet("get-foto/{userId}")]
        public async Task<dynamic> RetornarFotoUsuario(string userId)
        {
            var userDto = await _usuarioService.GetById(userId);

            return new { imagem = userDto.Foto };
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioUpdateDTO usuarioUpdate)
        {
            var usuario = await _usuarioService.GetById(usuarioUpdate.Id);

            await _usuarioService.UpdateUsuario(usuario, usuarioUpdate);

            return Ok(new
            {
                mensagem = $"Usuario {usuario.UserName} atualizado com sucesso."
            });
        }

    }
}
