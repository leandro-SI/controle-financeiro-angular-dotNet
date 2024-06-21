using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
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
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CriarUsuario(UsuarioDTO usuarioDto, string senha)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            return await _usuarioRepository.CriarUsuario(usuario, senha);
        }

        public async Task<int> GetQuantidade()
        {
            return await _usuarioRepository.GetQuantidade();
        }

        public async Task LogarUsuario(UsuarioDTO usuarioDto, bool lembrar)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.LogarUsuario(usuario, lembrar);
        }

        public async Task VincularUsuarioFuncao(UsuarioDTO usuarioDto, string funcao)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.VincularUsuarioFuncao(usuario, funcao);
        }
    }
}
