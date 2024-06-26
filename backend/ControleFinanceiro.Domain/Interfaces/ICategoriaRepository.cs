using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(long id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<Categoria> DeleteAsync(Categoria categoria);
        Task<IEnumerable<Categoria>> Filtrar(string nome);
        Task<IEnumerable<Categoria>> GetByTipo(string tipo);
    }
}
