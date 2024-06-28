using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class CartaoRepository : GenericRepository<Cartao>, ICartaoRepository
    {
        private readonly ApplicationDbContext _context;

        public CartaoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cartao>> GetByUserId(string userId)
        {
            return await _context.Cartoes.Where(c => c.UsuarioId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Cartao>> Filtrar(string nome)
        {
            return await _context.Cartoes
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
        }

        public async Task<int> GetQuantidadeByUser(string userId)
        {
            return await _context.Cartoes.CountAsync(c => c.UsuarioId == userId);
        }
    }
}
