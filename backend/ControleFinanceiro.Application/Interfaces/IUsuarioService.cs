using ControleFinanceiro.Application.Dtos;
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
        Task<IdentityResult> CriarUsuario(UsuarioDTO usuarioDto, string senha);
        Task VincularUsuarioFuncao(UsuarioDTO usuarioDto, string funcao);
        Task LogarUsuario(UsuarioDTO usuarioDto, bool lembrar);
    }
}
