using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class DespesaRepository : GenericRepository<Despesa>, IDespesaRepository
    {
        private readonly ApplicationDbContext _context;

        public DespesaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Despesa>> GetByUserId(string userId)
        {
            return await _context.Despesas
                .Include(d => d.Cartao)
                .Include(d => d.Categoria)
                .Include(d => d.Mes)
                .Where(d => d.UsuarioId == userId).ToListAsync();
        }


        public void DeleteDespesas(IEnumerable<Despesa> despesas)
        {
            _context.Despesas.RemoveRange(despesas);
        }

        public async Task<IEnumerable<Despesa>> GetByCartaoId(long cartaoId)
        {
            return await _context.Despesas
                .Include(d => d.Cartao)
                .Include(d => d.Categoria)
                .Include(d => d.Mes)
                .Where(d => d.CartaoId == cartaoId).ToListAsync();
        }

        public async Task<IEnumerable<Despesa>> Filtrar(string descricao, string tipo)
        {
            return await _context.Despesas
                .Include(d => d.Cartao)
                .Include(d => d.Categoria)
                .Include(d => d.Mes)
                .Where(c => c.Categoria.Nome.ToLower()
                .Contains(descricao.ToLower()) && c.Categoria.Tipo.Nome == tipo).ToListAsync();
        }

        public async Task<decimal> GetDespesaTotalByUserId(string userId)
        {
            return await _context.Despesas.Where(d => d.UsuarioId == userId).SumAsync(d => d.Valor);
        }
    }
}
