using Gamezee.Application.DTO.GameGroups;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameGroupController : ControllerBase
    {
        private readonly IGameGroupService _gameGroupService;

        public GameGroupController(IGameGroupService gameGroupService)
        {
            _gameGroupService = gameGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<GameGroupDTO>> Get(string id)
        {
            var gameGroup = await _gameGroupService.Read<GameGroupDTO>(id);
            return Ok(gameGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameGroupDTO dto)
        {
            var id = await _gameGroupService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameGroupDTO dto)
        {
            await _gameGroupService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _gameGroupService.DeleteAsync(id);
            return NoContent();
        }
    }
}
