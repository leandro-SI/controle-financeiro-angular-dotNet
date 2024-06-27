using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IGanhoRepository : IGenericRepository<Ganho>
    {
        Task<IEnumerable<Ganho>> GetByUserId(string userId);
        void DeleteGanhos(IEnumerable<Ganho> ganhos);
        Task<IEnumerable<Ganho>> Filtrar(string nomeCategoria, string tipo);
    }
}
