﻿using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> GetQuantidade();
        Task<UsuarioDTO> GetById(string id);
        Task<UsuarioDTO> GetByEmail(string email);
        Task<IList<string>> GetFuncoes(UsuarioDTO usuario);
        Task<bool> CriarUsuario(RegisterDTO registerDto, string senha);
        Task VincularUsuarioFuncao(UsuarioDTO usuarioDto, string funcao);
        Task LogarUsuario(UsuarioDTO usuarioDto, bool lembrar);
        string GerarToken(UsuarioDTO usuarioDTO, string funcao);
    }
}
