using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameGroupRepository : BaseRepository<IGameGroup, GameGroup>, IGameGroupRepository
    {
        public GameGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
