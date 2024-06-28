using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(ApplicationDbContext context, UserManager<Usuario> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<int> GetQuantidade()
        {
            return await _context.Usuarios.CountAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _userManager.UpdateAsync(usuario);
        }
    }
}
