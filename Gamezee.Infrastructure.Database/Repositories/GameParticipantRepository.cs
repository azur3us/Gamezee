using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameParticipantRepository : BaseRepository<IGameParticipant, GameParticipant, int>, IGameParticipantRepository
    {
        private readonly AppDbContext _context;

        public GameParticipantRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<IGameParticipant>> GetByGameAsync(string gameId) =>
            await _context.GameParticipants
            .AsNoTracking()
            .Where(x => x.GameId == gameId)
            .Select(x => (IGameParticipant)x)
            .ToListAsync();

        public async Task<IGameParticipant> GetByGameAsync(string gameId, int id) =>
           await _context.GameParticipants
           .AsNoTracking()
           .Where(x => x.GameId == gameId && x.Id == id)
           .FirstAsync();
    }
}
