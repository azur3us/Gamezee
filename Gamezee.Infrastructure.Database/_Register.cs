using Gamezee.Domain.Abstraction.Services;
using Gamezee.Domain.Repository;
using Gamezee.Infrastructure.Database.Authorization;
using Gamezee.Infrastructure.Database.Models;
using Gamezee.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gamezee.Infrastructure.Database
{
    public static class _Register
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Connection string cannot be null");
            }
      
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<AppUser>(options =>
            options.SignIn.RequireConfirmedEmail = false)
                .AddEntityFrameworkStores<AppDbContext>();

            //Register repositories
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameGroupRepository, GameGroupRepository>();
            services.AddScoped<IGameGroupMemberRepository, GameGroupMemberRepository>();
            services.AddScoped<IGameParticipantRepository, GameParticipantRepository>();
            services.AddScoped<IAuthService, AuthManegement>();

            return services;
        }

        public static IEndpointRouteBuilder UseMapIdentityApi(this IEndpointRouteBuilder app)
        {
            app.MapIdentityApi<AppUser>();

            return app;
        }
    }
}
