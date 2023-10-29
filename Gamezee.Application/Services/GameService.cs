using Gamezee.Application.DTO.Games;
using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Enums;
using Gamezee.Domain.Repository;

namespace Gamezee.Application.Services
{
    internal class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<string> CreateAsync(ICreateDTO dto)
        {
            var entity = _gameRepository.Instantiate();
            var createDto = (CreateGameDTO)dto;

            entity.Price = createDto.Price;
            entity.MinPlayers = createDto.MinPlayers;
            entity.MaxPlayers = createDto.MaxPlayers;
            entity.Duration = createDto.Duration;
            entity.Public = createDto.Public;
            entity.BenefitCard = createDto.BenefitCard;
            entity.Type = (EGameType)createDto.Type;
            entity.Day = createDto.Day;
            entity.DiscountWithBenefitCard = createDto.DiscountWithBenefitCard;
            entity.GroupId = createDto.GroupId;
            entity.StartTime = createDto.StartTime;

            await _gameRepository.CreateAsync(entity);
            return entity.Id;

        }

        public async Task DeleteAsync(string id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public Task<List<IReadDTO>> Read()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadDTO> Read(string id)
        {
            var entity = await _gameRepository.ReadAsync(id);
            return new GameDTO(entity);
        }

        public async Task UpdateAsync(IUpdateDTO dto)
        {
            var updateDto = (UpdateGameDTO)dto;
            var entity = await _gameRepository.ReadAsync(updateDto.Id);

            entity.Price = updateDto.Price;
            entity.MinPlayers = updateDto.MinPlayers;
            entity.MaxPlayers = updateDto.MaxPlayers;
            entity.Duration = updateDto.Duration;
            entity.Public = updateDto.Public;
            entity.BenefitCard = updateDto.BenefitCard;
            entity.Type = (EGameType)updateDto.Type;
            entity.Day = updateDto.Day;
            entity.DiscountWithBenefitCard = updateDto.DiscountWithBenefitCard;
            entity.GroupId = updateDto.GroupId;
            entity.StartTime = updateDto.StartTime;

            await _gameRepository.UpdateAsync(entity);
        }
    }
}
