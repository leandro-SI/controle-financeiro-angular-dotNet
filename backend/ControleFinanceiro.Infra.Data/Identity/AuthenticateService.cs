using ControleFinanceiro.Domain.Account;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthenticateService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IList<string>> GetFuncoes(Usuario usuario)
        {
            return await _userManager.GetRolesAsync(usuario);
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            await _signInManager.SignInAsync(usuario, false);

            _applicationDbContext.Entry(usuario).State = EntityState.Detached;
        }

        public async Task<bool> RegisterUser(Usuario usuario, string senha)
        {
            var result = await _userManager.CreateAsync(usuario, senha);

            //if (result.Succeeded)
            //{
            //    await _signInManager.SignInAsync(usuario, isPersistent: false);
            //}

            _applicationDbContext.Entry(usuario).State = EntityState.Detached;

            return result.Succeeded;
        }

        public async Task VincularUsuarioFuncao(Usuario usuario, string funcao)
        {
            _applicationDbContext.Entry(usuario).State = EntityState.Detached;
            var result = await _userManager.AddToRoleAsync(usuario, funcao);
        }
    }
}
