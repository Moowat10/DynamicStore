using DynamicStore.Data;
using DynamicStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var existingEntity = await _context.Set<T>().FindAsync(id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return existingEntity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEntity = await _context.Set<T>().FindAsync(id);

            if (existingEntity != null)
            {
                _context.Set<T>().Remove(existingEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
