using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IFuncaoRepository
    {
        Task<Funcao> GetByIdAsync(string id);
        Task AdicionarAsync(Funcao funcao);
        Task AtualizarAsync(Funcao funcao);
    }
}
