using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRane(IEnumerable<TEntity> entities);
    }
}
