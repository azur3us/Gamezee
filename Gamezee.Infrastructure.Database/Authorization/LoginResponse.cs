using Gamezee.Domain.Abstraction.Authorization;

namespace Gamezee.Infrastructure.Database.Authorization
{
    internal record LoginResponse : IAuthResponse
    {
        public bool Result { get; set; }
        public required string Token { get; set; }
    }
}
