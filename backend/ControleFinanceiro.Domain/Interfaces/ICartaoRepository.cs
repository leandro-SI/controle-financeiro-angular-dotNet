using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface ICartaoRepository : IGenericRepository<Cartao>
    {
        Task<IEnumerable<Cartao>> GetByUserId(string userId);
        Task<IEnumerable<Cartao>> Filtrar(string nome);
        Task<int> GetQuantidadeByUser(string userId);
    }
}
