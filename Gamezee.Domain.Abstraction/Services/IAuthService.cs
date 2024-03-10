using Gamezee.Domain.Abstraction.Authorization;

namespace Gamezee.Domain.Abstraction.Services
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(string email, string password);
        public Task<IAuthResponse> LoginAsync(string email, string password);
    }
}
