﻿namespace Gamezee.Application.DTO.Auth
{
    public record LoginDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
