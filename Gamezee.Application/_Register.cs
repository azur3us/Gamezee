using Gamezee.Application.Services;
using Gamezee.Domain.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gamezee.Application
{
    public static class _Register
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Service registration 
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameGroupService, GameGroupService>();

            return services;
        }
    }
}
