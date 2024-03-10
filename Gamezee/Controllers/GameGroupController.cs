using Gamezee.Application.DTO.GameGroups;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class GameGroupController : ControllerBase
    {
        private readonly IGameGroupService _gameGroupService;

        public GameGroupController(IGameGroupService gameGroupService)
        {
            _gameGroupService = gameGroupService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameGroupDTO>> Get(string id)
        {
            var gameGroup = await _gameGroupService.ReadAsync(id);
            return Ok(gameGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameGroupDTO dto)
        {
            var id = await _gameGroupService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateGameGroupDTO dto)
        {
            await _gameGroupService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _gameGroupService.DeleteAsync(id);
            return NoContent();
        }
    }
}
