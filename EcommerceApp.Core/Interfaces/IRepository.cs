using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Domain.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        IQueryable<TEntity> Queryable();
        Task<TEntity> FindAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TId> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }

}
