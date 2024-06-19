using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;


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

        public async Task<Funcao> GetByIdAsync(string id)
        {
            return await _context.Funcoes.FindAsync(id);
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


    }
}
