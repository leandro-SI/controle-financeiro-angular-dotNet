using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class FuncaoRepository : IFuncaoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<Funcao> _roleManager;

        public FuncaoRepository(ApplicationDbContext context, RoleManager<Funcao> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<Funcao>> GetAllAsync()
        {
            return await _context.Funcoes.ToListAsync();
        }

        public async Task<Funcao> GetByIdAsync(string id)
        {
            return await _context.Funcoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AdicionarAsync(Funcao funcao)
        {
            try
            {
                await _roleManager.CreateAsync(funcao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AtualizarAsync(Funcao funcao)
        {
            try
            {
                await _roleManager.UpdateAsync(funcao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(Funcao funcao)
        {
            await _roleManager.DeleteAsync(funcao);
        }

        public async Task<IEnumerable<Funcao>> Filtrar(string nome)
        {
            return await _context.Funcoes.Where(c => c.Name.ToLower().Contains(nome.ToLower())).ToListAsync();
        }
    }
}
