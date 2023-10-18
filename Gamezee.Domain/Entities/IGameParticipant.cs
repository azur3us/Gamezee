using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Entities
{
    public interface IGameParticipant : IEntity<int>
    {
        public string? PlayerFirstName { get; set; } 
        public string? PlayerLastName { get; set; }
        public string? PlayerId { get; set; }
        public string GameId { get; set; }
        public bool HasBenefitCard { get; set; }
    }
}
