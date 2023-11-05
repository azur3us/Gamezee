using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Entities;

namespace Gamezee.Application.DTO.GameParticipants
{
    public record GameParticipantDTO(IGameParticipant participant) : IReadDTO
    {
        public int Id { get; set; } = participant.Id;
        public string ParticipantName { get; set; } = participant.PlayerFirstName + " " + participant.PlayerLastName;
        public bool HasBenefitCard { get; set; } = participant.HasBenefitCard;
    }
}
