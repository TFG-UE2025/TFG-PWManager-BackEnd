using Microsoft.Extensions.DependencyInjection;
using TFG.PWManager.BackEnd.Jwt.Contracts;
using TFG.PWManager.BackEnd.Jwt.Services;

namespace TFG.PWManager.BackEnd.Jwt.Registration
{
    public static class JwtRegistration
    {
        public static IServiceCollection AddJwtServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();

            return services;
        }
    }
}
