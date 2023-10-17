using Gamezee.Infrastructure.Database.Models;
using Gamezee.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gamezee.Infrastructure.Database
{
    internal class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameParticipant> GameParticipants { get; set; }
        public DbSet<GameGroupMember> GameGroupMembers { get; set; }
        public DbSet<GameGroup> GameGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Game>()
                .ToTable(g => g.HasCheckConstraint("CK_Properties_MinPlayers_MaxPlayers", "[MaxPlayers] > [MinPlayers]"))
                .ToTable(g => g.HasCheckConstraint("CK_Properties_Duration_GreaterThan", "[Duration] > 0"));
        }
    }
}
