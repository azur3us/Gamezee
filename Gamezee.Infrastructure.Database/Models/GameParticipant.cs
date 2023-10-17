using Gamezee.Domain.Entities;
using Gamezee.Infrastructure.Database.Models;
using Gamezee.Infrastructure.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Gamezee.Infrastructure.Models
{
    internal record GameParticipant : BaseIntEntity, IGameParticipant
    {
        [MaxLength(150)]
        public string? PlayerFirstName { get; set; }
        [MaxLength(150)]
        public string? PlayerLastName { get; set; }
        public string? PlayerId { get; set; }
        public AppUser? Player { get; set; }
        public required string GameId { get; set; }
        public required Game Game { get; set; }
        public bool HasBenefitCard { get; set; }
    }
}
