using Domains;

namespace Domains.Contracts
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity> CreateAsync(TEntity item);
        Task<bool> UpdateAsync(TEntity item);
        Task<bool> DeleteAsync(TId id);
        Task<int> SaveOnDbAsync();
    }
}
