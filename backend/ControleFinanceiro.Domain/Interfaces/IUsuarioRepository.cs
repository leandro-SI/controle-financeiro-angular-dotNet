using ControleFinanceiro.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<int> GetQuantidade();
        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);
        Task VincularUsuarioFuncao(Usuario usuario, string funcao);
        Task LogarUsuario(Usuario usuario, bool lembrar);
        Task<Usuario> GetByEmail(string email);

    }
}
