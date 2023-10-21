namespace Gamezee.Application.DTO.Games
{
    public record GameDTO
    {
        public int Type { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string? GroupId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public bool BenefitCard { get; set; }
        public bool Canceled { get; set; }
        public bool Public { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountWithBenefitCard { get; set; }
    }
}
