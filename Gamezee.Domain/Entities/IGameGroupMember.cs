using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Entities
{
    public interface IGameGroupMember : IEntity
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public int GameAttendance { get; set; }
        public int? SkillRate { get; set; }
    }
}
