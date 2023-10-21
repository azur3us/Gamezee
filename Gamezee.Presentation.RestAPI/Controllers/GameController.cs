using Gamezee.Application.DTO.Games;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(string id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameDTO dto)
        {
            return CreatedAtAction(nameof(Create), null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update()
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _gameService.DeleteAsync(id);
            return NoContent();
        }
    }
}
