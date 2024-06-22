using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioRepository(ApplicationDbContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);
        }

        public async Task<int> GetQuantidade()
        {
            return await _context.Usuarios.CountAsync();
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _signInManager.SignInAsync(usuario, false);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }

        public async Task VincularUsuarioFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _userManager.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
