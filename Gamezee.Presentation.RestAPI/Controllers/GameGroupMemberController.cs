using Gamezee.Application.DTO.GameGroupMembers;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamezee.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameGroupMemberController : ControllerBase
    {
        private readonly IGameGroupMemberService _gameGroupMemberService;

        public GameGroupMemberController(IGameGroupMemberService gameGroupMemberService)
        {
            _gameGroupMemberService = gameGroupMemberService;
        }

        [HttpGet("{gameGroupId}")]
        public async Task<ActionResult<List<GameGroupMemberDTO>>> Get(string gameGroupId)
        {
            var members = await _gameGroupMemberService.GetAsync(gameGroupId);

            return Ok(members);
        }

        [HttpGet("{gameGroupId}/{userId}")]
        public async Task<ActionResult<GameGroupMemberDTO>> Get(string gameGroupId, string userId)
        {
            var member = await _gameGroupMemberService.GetAsync(gameGroupId, userId);

            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGameGroupMember dto)
        {
            await _gameGroupMemberService.CreateAsync(dto.UserId, dto.GroupId);
            return CreatedAtAction(nameof(Create), dto);
        }

        [HttpPut("{gameGroupId}/{userId}")]
        public async Task<IActionResult> Update(string gameGroupId, string userId, [FromBody] UpdateGameGroupMember dto)
        {
            await _gameGroupMemberService.SetSkillRate(userId, gameGroupId, dto.SkillRate);

            return NoContent();
        }

        [HttpDelete("{gameGroupId}/{userId}")]
        public async Task<IActionResult> Delete(string userId, string groupId)
        {
            await _gameGroupMemberService.DeleteAsync(userId, groupId);
            return NoContent();
        }

    }
}
