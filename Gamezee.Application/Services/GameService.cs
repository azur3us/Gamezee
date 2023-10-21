using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services;
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

        public Task<string> CreateAsync(ICreateDTO dto)
        {
            throw new NotImplementedException();
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
