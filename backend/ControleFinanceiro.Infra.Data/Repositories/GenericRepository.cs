using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> FindById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> FindById(long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task Create(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await FindById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var entity = await FindById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            var registro = _context.Set<T>().Update(entity);
            registro.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> FindById(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }
    }
}
