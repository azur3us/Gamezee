using Gamezee.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Gamezee.Infrastructre.Identity.Models
{
    internal class AppUser : IdentityUser, IAppUser
    {
    }
}
