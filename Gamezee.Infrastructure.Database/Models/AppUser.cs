using Gamezee.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Gamezee.Infrastructure.Database.Models
{
    internal class AppUser : IdentityUser, IAppUser
    {
        public bool HasBenefitCard { get; set; }
    }
}
