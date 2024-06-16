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
    public class TipoRepository : ITipoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tipo>> GetAllAsync()
        {
            return await _context.Tipos.ToListAsync();
        }
    }
}
