using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Domain.Abstraction.Services
{
    public interface IGameGroupMemberService 
    {
        Task<List<IReadDTO>> GetAsync(string groupId);
        Task<IReadDTO> GetAsync(string groupId, string userId);
        Task CreateAsync(string userId, string groupId);
        Task DeleteAsync(string userId, string groupId);
        Task SetSkillRate(string userId, string groupId, int? skillRate);

    }
}
