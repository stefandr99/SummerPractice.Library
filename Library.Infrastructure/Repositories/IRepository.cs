using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);

        Task<List<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task DeleteAsync(Guid id);

        Task SaveChangesAsync();
    }
}
