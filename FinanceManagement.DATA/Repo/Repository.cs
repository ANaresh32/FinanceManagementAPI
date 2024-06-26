using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace FinanceManagement.DATA.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FinanceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(FinanceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        /*public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }*/
    }
}
