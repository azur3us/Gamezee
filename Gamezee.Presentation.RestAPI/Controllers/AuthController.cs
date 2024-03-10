using Gamezee.Application.DTO.Auth;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            try
            {
                var result = await _authService.RegisterAsync(dto.Email, dto.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var loginResult = await _authService.LoginAsync(dto.Email, dto.Password);
                return Ok(loginResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
