using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameRepository : BaseRepository<IGame, Game, string>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {
        }
    }
}
