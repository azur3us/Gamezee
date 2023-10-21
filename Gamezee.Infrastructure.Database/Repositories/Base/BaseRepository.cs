using Gamezee.Domain.Entities.Base;
using Gamezee.Domain.Repository.Base;

namespace Gamezee.Infrastructure.Database.Repositories.Base
{
    internal abstract class BaseRepository<TInterface, TEntity> : IBaseRepository<TInterface>
        where TEntity : class, TInterface
        where TInterface : IEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task CreateAsync(TInterface entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task CreateRangeAsync(IEnumerable<TInterface> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TInterface entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync<TKey>(TKey id)
        {
            var entity = await this.ReadAsync(id);
            await this.DeleteAsync(entity);
        }

        public virtual async Task DeleteRange(IEnumerable<TInterface> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TInterface entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public TInterface Instantiate()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public virtual async Task<IEntity> ReadAsync<TKey>(TKey id)
        {
            var entity = await _context.FindAsync<IEntity>(id);

            if (entity is null)
                throw new ArgumentNullException($"Cannot find entity with id:{id}");

            return entity;
        }
    }
}
