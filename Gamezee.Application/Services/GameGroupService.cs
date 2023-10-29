﻿using Gamezee.Application.DTO.GameGroups;
using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Entities;
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

        public async Task DeleteAsync(string id)
        {
            await _gameGroupRepository.DeleteAsync(id);
        }

        public Task<List<IReadDTO>> Read()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadDTO> Read(string id)
        {
            var entity = await _gameGroupRepository.ReadAsync(id);
            return new GameGroupDTO(entity);
        }

        public async Task UpdateAsync(IUpdateDTO dto)
        {
            var updateDto = (UpdateGameGroupDTO)dto;
            var entity = await _gameGroupRepository.ReadAsync(updateDto.Id);
            entity.Name = updateDto.Name;
            await _gameGroupRepository.UpdateAsync(entity);

        }
    }
}
