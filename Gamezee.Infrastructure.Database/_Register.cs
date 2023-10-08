using Gamezee.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;


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

            services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            services.AddAuthorizationBuilder();

            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(connectionString));

            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();

            return services;
        }

        public static IEndpointRouteBuilder UseMapIdentityApi(this IEndpointRouteBuilder app)
        {
            app.MapIdentityApi<AppUser>();

            return app;
        }
    }
}
