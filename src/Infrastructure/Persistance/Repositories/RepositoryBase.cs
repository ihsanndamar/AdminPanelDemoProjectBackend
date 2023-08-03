using Application.Interfaces;
using Domain.Common;
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


        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
