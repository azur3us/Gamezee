using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services.Base;

namespace Gamezee.Domain.Abstraction.Services
{
    public interface IGameParticipantService : ICRUDService<int, ICreateDTO, IUpdateDTO, IReadDTO>
    {
        Task<List<IReadDTO>> ReadAsync<TReadDTO>(string gameId) where TReadDTO : IReadDTO;
        Task<IReadDTO> ReadAsync(string gameId, int id);
        Task UpdateAsync(string gameId, int id, IUpdateDTO dto);
    }
}
