using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IFuncaoRepository
    {
        Task<IEnumerable<Funcao>> GetAllAsync();
        Task<Funcao> GetByIdAsync(string id);
        Task AdicionarAsync(Funcao funcao);
        Task AtualizarAsync(Funcao funcao);
        Task DeleteAsync(Funcao funcao);
        Task<IEnumerable<Funcao>> Filtrar(string nome);
    }
}
