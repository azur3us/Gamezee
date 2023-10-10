using Gamezee.Domain.Entities.Base;
using Gamezee.Domain.Enums;

namespace Gamezee.Domain.Entities
{
    public interface IGame : IBaseEntity
    {
        public EGameType Type { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int? GroupId { get; set; }
        public IGameGroup GameGroup { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public bool BenefitCard { get; set; }
        public bool Canceled { get; set; }
        public bool Public { get; set; }

    }
}
