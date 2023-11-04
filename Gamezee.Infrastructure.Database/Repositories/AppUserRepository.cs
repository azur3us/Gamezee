using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Models;
using Gamezee.Infrastructure.Database.Repositories.Base;

namespace Gamezee.Infrastructure.Database.Repositories
{
    internal class AppUserRepository : BaseRepository<IAppUser, AppUser, string>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
