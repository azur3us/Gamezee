using Gamezee.Domain.Entities;
using Gamezee.Domain.Enums;
using Gamezee.Infrastructure.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Gamezee.Infrastructure.Models
{
    internal record Game : BaseStringEntity, IGame
    {
        public Game()
        {
            GameParticipants = new HashSet<GameParticipant>();
        }

        public EGameType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;
        [Range(1, 100)]
        public int MinPlayers { get; set; }
        [Range(1, 100)]
        public int MaxPlayers { get; set; }
        public string? GroupId { get; set; }
        public GameGroup? Group { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public bool BenefitCard { get; set; }
        public bool Canceled { get; set; }
        public bool Public { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountWithBenefitCard { get; set; }
        public required GameAddress Address { get; set; }
        public virtual ICollection<GameParticipant> GameParticipants { get; set; }

    }
}
