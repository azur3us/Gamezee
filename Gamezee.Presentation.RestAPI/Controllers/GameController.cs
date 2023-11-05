using Gamezee.Application.DTO.Games;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
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
        public async Task<ActionResult<GameDTO>> GetGame(string id)
        {
            return Ok(await _gameService.ReadAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameDTO dto)
        {
            var id = await _gameService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateGameDTO dto)
        {
            await _gameService.UpdateAsync(id, dto);
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
