using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameParticipantRepository : BaseRepository<IGameParticipant, GameParticipant>, IGameParticipantRepository
    {
        public GameParticipantRepository(AppDbContext context) : base(context)
        {
        }
    }
}
