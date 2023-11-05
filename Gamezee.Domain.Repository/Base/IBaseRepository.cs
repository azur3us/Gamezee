using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Repository.Base
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : IEntity
    {
        Task<TEntity> GetAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TEntity entity);
        Task DeleteRange(IEnumerable<TEntity> entities);
        public TEntity Instantiate();
    }
}
