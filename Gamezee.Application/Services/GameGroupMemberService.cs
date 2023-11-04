using Gamezee.Application.DTO.GameGroupMembers;
using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Repository;

namespace Gamezee.Application.Services
{
    internal class GameGroupMemberService : IGameGroupMemberService
    {
        private readonly IGameGroupMemberRepository _gameGroupMemberRepository;

        public GameGroupMemberService(IGameGroupMemberRepository gameGroupMemberRepository)
        {
            _gameGroupMemberRepository = gameGroupMemberRepository;
        }

        public async Task CreateAsync(string userId, string groupId)
        {
            var entity = _gameGroupMemberRepository.Instantiate();
            entity.UserId = userId;
            entity.GroupId = groupId;
            await _gameGroupMemberRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(string userId, string groupId)
        {
            await _gameGroupMemberRepository.DeleteAsync((userId, groupId));
        }

        public async Task<List<IReadDTO>> GetAsync(string groupId) =>
                (await _gameGroupMemberRepository.GetMembersAsync(groupId))
               .Select(x => (IReadDTO)new GameGroupMemberDTO(x, groupId))
               .ToList();

        public async Task<IReadDTO> GetAsync(string groupId, string userId)
        {
            return new GameGroupMemberDTO(await _gameGroupMemberRepository.GetMemberAsync(groupId, userId), groupId);
        }

        public async Task SetSkillRate(string userId, string groupId, int? skillRate)
        {
            var entity = await _gameGroupMemberRepository.ReadAsync((userId, groupId));
            entity.SkillRate = skillRate;
            await _gameGroupMemberRepository.UpdateAsync(entity);
        }
    }
}
