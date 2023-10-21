using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        Task<IEntity> ReadAsync<TKey>(TKey id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync<TKey>(TKey id);
        Task DeleteAsync(TEntity entity);
        Task DeleteRange(IEnumerable<TEntity> entities);
        public TEntity Instantiate();
    }
}
