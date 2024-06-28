using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class GanhoRepository : GenericRepository<Ganho>, IGanhoRepository
    {
        private readonly ApplicationDbContext _context;

        public GanhoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ganho>> GetByUserId(string userId)
        {
            return await _context.Ganhos
                .Include(d => d.Categoria)
                .Include(d => d.Mes)
                .Where(d => d.UsuarioId == userId).ToListAsync();
        }

        public void DeleteGanhos(IEnumerable<Ganho> ganhos)
        {
            _context.Ganhos.RemoveRange(ganhos);
        }

        public async Task<IEnumerable<Ganho>> Filtrar(string nomeCategoria, string tipo)
        {
            return await _context.Ganhos
                .Include(d => d.Categoria)
                .Include(d => d.Mes)
                .Where(c => c.Categoria.Nome.ToLower()
                .Contains(nomeCategoria.ToLower()) && c.Categoria.Tipo.Nome == tipo).ToListAsync();
        }

        public async Task<decimal> GetGanhoTotalByUserId(string userId)
        {
            return await _context.Ganhos.Where(g => g.UsuarioId == userId).SumAsync(g => g.Valor);
        }
    }
}
