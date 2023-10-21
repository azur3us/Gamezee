using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameGroupMemberRepository : BaseRepository<IGameGroupMember, GameGroupMember>, IGameGroupMemberRepository
    {
        public GameGroupMemberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
