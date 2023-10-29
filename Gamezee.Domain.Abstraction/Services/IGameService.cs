using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Abstraction.Services.Base;

namespace Gamezee.Domain.Abstraction.Services
{
    public interface IGameService : ICRUDService<string, ICreateDTO, IUpdateDTO, IReadDTO>
    {
    }
}
