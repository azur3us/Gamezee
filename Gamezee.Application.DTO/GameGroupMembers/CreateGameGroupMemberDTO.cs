namespace Gamezee.Application.DTO.GameGroupMembers
{
    public record CreateGameGroupMemberDTO
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
    }
}
