using Gamezee.Domain.Abstraction.Dtos;
using Gamezee.Domain.Entities;

namespace Gamezee.Application.DTO.Games
{
    public record GameDTO(IGame game) : IReadDTO
    {
        public string Id { get; set; } = game.Id;
        public int Type { get; set; } = (int)game.Type;
        public int MinPlayers { get; set; } = game.MinPlayers;
        public int MaxPlayers { get; set; } = game.MaxPlayers;
        public string? GroupId { get; set; } = game.GroupId;
        public DayOfWeek Day { get; set; } = game.Day;
        public TimeSpan StartTime { get; set; } = game.StartTime;
        public int Duration { get; set; } = game.Duration;
        public bool BenefitCard { get; set; } = game.BenefitCard;
        public bool Canceled { get; set; } = game.Canceled;
        public bool Public { get; set; } = game.Public;
        public decimal? Price { get; set; } = game.Price;
        public decimal? DiscountWithBenefitCard { get; set; } = game.DiscountWithBenefitCard;
    }
}
