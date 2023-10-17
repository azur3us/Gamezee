using Gamezee.Domain.Entities;
using Gamezee.Infrastructure.Database.Models;
using Gamezee.Infrastructure.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Gamezee.Infrastructure.Models
{
    internal record GameGroup : BaseStringEntity, IGameGroup
    {
        public GameGroup()
        {
            GameGroupMembers = new HashSet<GameGroupMember>();
        }
        [MaxLength(120)]
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;
        public required string CreatorId { get; set; }
        public AppUser Creator { get; set; }
        public virtual ICollection<GameGroupMember> GameGroupMembers { get; set; }
    }
}
