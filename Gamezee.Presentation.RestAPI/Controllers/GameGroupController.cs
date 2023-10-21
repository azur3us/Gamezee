using Gamezee.Application.DTO.GameGroups;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class GameGroupController : ControllerBase
    {
        private readonly IGameGroupService _gameGroupService;

        public GameGroupController(IGameGroupService gameGroupService)
        {
            _gameGroupService = gameGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameGroupDTO dto)
        {
            var id = await _gameGroupService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), id);
        }
    }
}
