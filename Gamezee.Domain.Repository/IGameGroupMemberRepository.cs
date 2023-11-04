using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository.Base;

namespace Gamezee.Domain.Repository
{
    public interface IGameGroupMemberRepository : IBaseRepository<IGameGroupMember, (string userId, string groupId)>
    {
        Task<IEnumerable<(string userId, string? userName, int attendance, int? skillRate)>> GetMembersAsync(string groupId);
        Task<(string userId, string? userName, int attendance, int? skillRate)> GetMemberAsync(string groupId, string userId);
    }
}
