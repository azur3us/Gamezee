namespace Gamezee.Application.DTO.Auth
{
    public record RegisterDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
