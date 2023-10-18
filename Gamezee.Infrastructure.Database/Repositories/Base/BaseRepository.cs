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

        public async Task CreateAsync(TInterface entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<TInterface> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TInterface entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRane(IEnumerable<TInterface> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TInterface entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
