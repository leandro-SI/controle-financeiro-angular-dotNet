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
    public class GraficoRepository : IGraficoRepository
    {
        private readonly ApplicationDbContext _context;

        public GraficoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetDespesasAnuaisByUsuarioId(string userId, int ano)
        {
            return await _context.Despesas
                .Where(d => d.UsuarioId == userId && d.Ano == ano)
                .OrderBy(d => d.Mes.Id)
                .GroupBy(d => d.Mes.Id)
                .Select(d => new
                {
                    MesId = d.Key,
                    valores = d.Sum(x => x.Valor)
                }).ToListAsync();
        }

        public async Task<object> GetGanhosAnuaisByUsuarioId(string userId, int ano)
        {
            return await _context.Ganhos
                .Where(g => g.UsuarioId == userId && g.Ano == ano)
                .OrderBy(g => g.Mes.Id)
                .GroupBy(g => g.Mes.Id)
                .Select(g => new
                {
                    MesId = g.Key,
                    valores = g.Sum(x => x.Valor)
                }).ToListAsync();
        }
    }
}
