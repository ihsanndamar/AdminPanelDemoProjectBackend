using Domain.Common;


namespace Application.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid Id);
    }
}
