using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface ICartaoRepository : IGenericRepository<Cartao>
    {
        Task<IEnumerable<Cartao>> GetByUserId(string userId);
    }
}
