using Microsoft.Extensions.DependencyInjection;
using TFG.PWManager.BackEnd.Hash.Contracts;
using TFG.PWManager.BackEnd.Hash.Services;

namespace TFG.PWManager.BackEnd.Hash.Registration
{
    public static class HashRegistration
    {
        public static IServiceCollection AddHashServices(this IServiceCollection services)
        {
            services.AddTransient<IHashService, HashService>();

            return services;
        }
    }
}
