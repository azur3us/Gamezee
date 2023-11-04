namespace Gamezee.Application.DTO.GameGroupMembers
{
    public record CreateGameGroupMember
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
    }
}
