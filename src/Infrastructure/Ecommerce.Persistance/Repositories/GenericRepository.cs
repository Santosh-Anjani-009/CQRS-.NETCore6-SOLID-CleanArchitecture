using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var old =await GetAsync(id);
            _context.Set<T>().Remove(old);
            await SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entry = await GetAsync(id);
            return entry != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var entry = await _context.Set<T>().FindAsync(id);
            return entry;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
