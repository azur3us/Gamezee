using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Entities;

namespace Gamezee.Application.DTO.GameGroups
{
    public record GameGroupDTO(IGameGroup gameGroup) : IReadDTO 
    {
        public string Id { get; set; } = gameGroup.Id;
        public string Name { get; set; } = gameGroup.Name;
    }
}
