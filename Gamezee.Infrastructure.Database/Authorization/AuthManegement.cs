using Gamezee.Domain.Abstraction.Authorization;
using Gamezee.Domain.Abstraction.Services;
using Gamezee.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gamezee.Infrastructure.Database.Authorization
{
    internal class AuthManegement : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthManegement(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IAuthResponse> LoginAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
                throw new Exception("Password or email is invalid");

            var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, password);

            if (!isPasswordValid)
                throw new Exception("Password or email is invalid");

            var token = GenerateJwtToken(existingUser);

            return new LoginResponse
            {
                Result = true,
                Token = token
            };
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var emailExists = await _userManager.FindByEmailAsync(email);

            if (emailExists != null)
                throw new Exception("Account with that email already exists");

            var newUser = new AppUser()
            {
                Email = email,
                UserName = email
            };

            var isCreated = await _userManager.CreateAsync(newUser, password);

            return isCreated.Succeeded;
        }

        private string GenerateJwtToken(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("DjPxYgkhUdQJczVusAvUEXCrycVxaJ12345678901234567890123456789012dQijj");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512),
            };

            var jwtToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(jwtToken);
        }
    }
}
