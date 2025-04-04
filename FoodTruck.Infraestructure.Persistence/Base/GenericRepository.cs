using FoodTruck.Core.Domain.Repositories;
using FoodTruck.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infraestructure.Persistence.Base
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
