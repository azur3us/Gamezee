using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository.Base;

namespace Gamezee.Domain.Repository
{
    public interface IGameParticipantRepository : IBaseRepository<IGameParticipant, int>
    {
        Task<List<IGameParticipant>> GetByGameAsync(string gameId);
        Task<IGameParticipant> GetByGameAsync(string gameId, int id);
    }
}
