using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Repositories.Base;
using Gamezee.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class GameGroupMemberRepository : BaseRepository<IGameGroupMember, GameGroupMember, (string userId, string groupId)>, IGameGroupMemberRepository
    {
        private readonly AppDbContext _context;

        public GameGroupMemberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(string userId, string? userName, int attendance, int? skillRate)> GetMemberAsync(string groupId, string userId)
        {
            var member = await _context.GameGroupMembers
                 .AsNoTracking()
                .Include(x => x.UserId)
                .Where(x => x.GroupId == groupId)
                .Select(x => new { x.UserId, x.User.UserName, x.GameAttendance, x.SkillRate })
                .FirstOrDefaultAsync();

            if (member == null)
            {
                throw new ArgumentNullException($"Cannot find member with id {userId} for group with id: {groupId}");
            }

            return (member.UserId, member.UserName, member.GameAttendance, member.SkillRate);
        }

        public async Task<IEnumerable<(string userId, string? userName, int attendance, int? skillRate)>> GetMembersAsync(string groupId) => (await _context.GameGroupMembers
                .AsNoTracking()
                .Include(x => x.UserId)
                .Where(x => x.GroupId == groupId)
                .Select(x => new { x.UserId, x.User.UserName, x.GameAttendance, x.SkillRate })
                .ToListAsync())
                .Select(x => (x.UserId, x.UserName, x.GameAttendance, x.SkillRate));
    }
}
