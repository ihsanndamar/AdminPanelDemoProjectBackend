using Application.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Task<T> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
