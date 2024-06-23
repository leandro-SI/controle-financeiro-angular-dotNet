using AutoMapper;
using ControleFinanceiro.Application.Authentications;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Account;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticate _authenticateService;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IAuthenticate authenticateService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _authenticateService = authenticateService;
        }

        public async Task<UsuarioDTO> GetById(string id)
        {
            var entity = await _usuarioRepository.FindById(id);

            return _mapper.Map<UsuarioDTO>(entity);
        }

        public async Task<bool> CriarUsuario(RegisterDTO registerDto, string senha)
        {

            var usuarioDto = new UsuarioDTO
            {
                UserName = registerDto.NomeUsuario,
                Email = registerDto.Email,
                PasswordHash = registerDto.Senha,
                CPF = registerDto.CPF,
                Profissao = registerDto.Profissao,
                Foto = registerDto.Foto
            };

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            return await _authenticateService.RegisterUser(usuario, senha);

        }

        public async Task<int> GetQuantidade()
        {
            return await _usuarioRepository.GetQuantidade();
        }

        public async Task<IList<string>> GetFuncoes(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            return await _authenticateService.GetFuncoes(usuario);
        }

        public async Task LogarUsuario(UsuarioDTO usuarioDto, bool lembrar)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _authenticateService.LogarUsuario(usuario, lembrar);
        }

        public async Task VincularUsuarioFuncao(UsuarioDTO usuarioDto, string funcao)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _authenticateService.VincularUsuarioFuncao(usuario, funcao);
        }

        public async Task<UsuarioDTO> GetByEmail(string email)
        {
            var entity = await _authenticateService.GetByEmail(email);

            return _mapper.Map<UsuarioDTO>(entity);
        }

        public string GerarToken(UsuarioDTO usuarioDTO, string funcao)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            return TokenService.GerarToken(usuario, funcao);
        }

    }
}
