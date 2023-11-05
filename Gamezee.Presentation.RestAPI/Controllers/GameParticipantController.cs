using Gamezee.Application.DTO.GameParticipants;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameParticipantController : ControllerBase
    {
        private readonly IGameParticipantService _gameParticipantService;

        public GameParticipantController(IGameParticipantService gameParticipantService)
        {
            _gameParticipantService = gameParticipantService;
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<List<GameParticipantDTO>>> Get(string gameId)
        {
            return Ok(await _gameParticipantService.ReadAsync<GameParticipantDTO>(gameId));
        }

        [HttpGet("{gameId}/{id}")]
        public async Task<ActionResult<GameParticipantDTO>> Get(string gameId,int id)
        {
            return Ok(await _gameParticipantService.ReadAsync(gameId,id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameParticipantDTO dto)
        {
            var id = await _gameParticipantService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), id);
        }

        [HttpPut("{gameId}/{id}")]
        public async Task<IActionResult> Update(string gameId, int id, [FromBody] UpdateGameParicipantDTO dto)
        {
            await _gameParticipantService.UpdateAsync(gameId, id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            await _gameParticipantService.DeleteAsync(id);
            return NoContent();
        }
    }
}
