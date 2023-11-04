using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Application.DTO.GameGroupMembers
{
    public record GameGroupMemberDTO((string userId, string? userName, int attendance, int? skillRate) member, string groupId) : IReadDTO
    {
        public string GroupId { get; set; } = groupId;
        public  string UserId { get; set; } = member.userId;
        public string? UserName { get; set; } = member.userName;
        public int Attendace { get; set; } = member.attendance;
        public int? SkillRate { get; set; } = member.skillRate;
    }
}
