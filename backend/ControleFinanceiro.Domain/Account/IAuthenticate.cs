using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> RegisterUser(Usuario usuario, string senha);
        Task<Usuario> GetByEmail(string email);
        Task LogarUsuario(Usuario usuario, bool lembrar);
        Task VincularUsuarioFuncao(Usuario usuario, string funcao);
        Task<IList<string>> GetFuncoes(Usuario usuario);
    }
}
