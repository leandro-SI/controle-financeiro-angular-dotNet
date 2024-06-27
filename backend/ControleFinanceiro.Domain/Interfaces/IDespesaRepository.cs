using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IDespesaRepository : IGenericRepository<Despesa>
    {
        Task<IEnumerable<Despesa>> GetByUserId(string userId);
        Task<IEnumerable<Despesa>> GetByCartaoId(long cartaoId);
        void DeleteDespesas(IEnumerable<Despesa> despesas);
        Task<IEnumerable<Despesa>> Filtrar(string descricao, string tipo);
    }
}
