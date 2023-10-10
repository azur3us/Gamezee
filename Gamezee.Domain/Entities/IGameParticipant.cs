using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Entities
{
    internal interface IGameParticipant : IBaseEntity
    {
        public string? PlayerFirstName { get; set; } 
        public string? PlayerLastName { get; set; }
        public string? PlayerId { get; set; }
        public IAppUser Player { get; set; }
        public int GameId { get; set; }
        public IGame Game { get; set; }
        public bool HasBenefitCard { get; set; }
    }
}
