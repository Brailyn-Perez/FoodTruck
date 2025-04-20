using FoodTruck.Core.Domain.Common;
using FoodTruck.Core.Domain.Repositories;
using FoodTruck.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infraestructure.Persistence.Base
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
