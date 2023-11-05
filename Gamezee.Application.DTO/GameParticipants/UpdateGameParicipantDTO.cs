using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Application.DTO.GameParticipants
{
    public record UpdateGameParicipantDTO : IUpdateDTO
    {
        public string? PlayerFirstName { get; set; }
        public string? PlayerLastName { get; set; }
        public string? PlayerId { get; set; }
        public bool HasBenefitCard { get; set; }
    }
}
