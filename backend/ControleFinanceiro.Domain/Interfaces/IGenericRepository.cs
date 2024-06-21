using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> FindById(int id);
        Task<T> FindById(string id);
        Task<IEnumerable<T>> FindAll();
        Task Update(T entity);
        Task Delete(int id);
    }
}
