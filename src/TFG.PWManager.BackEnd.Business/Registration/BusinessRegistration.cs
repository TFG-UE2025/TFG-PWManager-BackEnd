using Microsoft.Extensions.DependencyInjection;
using TFG.PWManager.BackEnd.Business.Services;
using TFG.PWManager.BackEnd.Domain.Contracts.Services;
using TFG.PWManager.BackEnd.Domain.Custom;

namespace TFG.PWManager.BackEnd.Business.Registration
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();           
            services.AddScoped<IUserService, UserService>();            
            services.AddScoped<CurrentUserProvider>();

            return services;
        }
    }
}
