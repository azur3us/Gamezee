using Gamezee.Application.DTO.GameGroups;
using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Repository;

namespace Gamezee.Application.Services
{
    internal class GameGroupService : IGameGroupService
    {
        private readonly IGameGroupRepository _gameGroupRepository;

        public GameGroupService(IGameGroupRepository gameGroupRepository)
        {
            _gameGroupRepository = gameGroupRepository;
        }

        public async Task<string> CreateAsync(ICreateDTO dto)
        {
            var entity = _gameGroupRepository.Instantiate();
            var castedDto = (CreateGameGroupDTO)dto;
            entity.CreatedAt = castedDto.CreatedAt;
            entity.CreatorId = castedDto.CreatorId;
            entity.Name = castedDto.Name;
            await _gameGroupRepository.CreateAsync(entity);
            return entity.Id;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Read<T>()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
