using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Application.DTO.GameGroups
{
    public record UpdateGameGroupDTO : IUpdateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
