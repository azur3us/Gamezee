using Gamezee.Domain.Entities;
using Gamezee.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamezee.Infrastructure.Models
{
    [PrimaryKey(nameof(UserId), nameof(GroupId))]
    internal record GameGroupMember : IGameGroupMember
    {
        public required string UserId { get; set; }
        public required AppUser User { get; set; }
        public required string GroupId { get; set; }
        public required GameGroup Group { get; set; }
        public int GameAttendance { get; set; }
        public int? SkillRate { get; set; }
    }
}
