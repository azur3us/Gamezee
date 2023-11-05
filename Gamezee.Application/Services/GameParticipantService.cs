using Gamezee.Application.DTO.GameParticipants;
using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Repository;

namespace Gamezee.Application.Services
{
    internal class GameParticipantService : IGameParticipantService
    {
        private readonly IGameParticipantRepository _gameParticipantRepository;

        public GameParticipantService(IGameParticipantRepository gameParticipantRepository)
        {
            _gameParticipantRepository = gameParticipantRepository;
        }

        public async Task<int> CreateAsync(ICreateDTO dto)
        {
            var entity = _gameParticipantRepository.Instantiate();
            var createDto = (CreateGameParticipantDTO)dto;

            entity.HasBenefitCard = createDto.HasBenefitCard;
            entity.PlayerLastName = createDto.PlayerLastName;
            entity.PlayerFirstName = createDto.PlayerFirstName;
            entity.GameId = createDto.GameId;
            entity.PlayerId = createDto.PlayerId;

            await _gameParticipantRepository.CreateAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _gameParticipantRepository.DeleteAsync(id);
        }

        public Task<List<IReadDTO>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadDTO> ReadAsync(string gameId, int id)
        {
            var entity = await _gameParticipantRepository.GetByGameAsync(gameId, id);
            return new GameParticipantDTO(entity);
        }

        public async Task<List<IReadDTO>> ReadAsync<TReadDTO>(string gameId) where TReadDTO : IReadDTO
        {
            return (await _gameParticipantRepository.GetByGameAsync(gameId))
                .Select(x => (IReadDTO)(new GameParticipantDTO(x)))
                .ToList();
                
        }

        public async Task<IReadDTO> ReadAsync(int id)
        {
            var entity = await _gameParticipantRepository.GetAsync(id);
            return new GameParticipantDTO(entity);
        }

        public Task UpdateAsync(int id, IUpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(string gameId, int id, IUpdateDTO dto)
        {
            var entity = await _gameParticipantRepository.GetByGameAsync(gameId, id);
            var updateDto = (UpdateGameParicipantDTO)dto;

            if (string.IsNullOrWhiteSpace(updateDto.PlayerId))
            {
                entity.PlayerLastName = updateDto.PlayerLastName;
                entity.PlayerFirstName = updateDto.PlayerFirstName;
            }

            entity.PlayerId = updateDto.PlayerId;
            entity.HasBenefitCard = updateDto.HasBenefitCard;

            await _gameParticipantRepository.UpdateAsync(entity);
        }
    }
}
