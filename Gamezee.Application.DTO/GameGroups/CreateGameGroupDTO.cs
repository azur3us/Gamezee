using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Application.DTO.GameGroups
{
    public record CreateGameGroupDTO : ICreateDTO
    {
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;
        public required string CreatorId { get; set; }
    }
}
