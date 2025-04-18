using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TFG.PWManager.BackEnd.Domain.Contracts.Persistence;
using TFG.PWManager.BackEnd.Infrastructure.Context;
using TFG.PWManager.BackEnd.Infrastructure.Persistence;

namespace TFG.PWManager.BackEnd.Infrastructure.Registration
{
    [ExcludeFromCodeCoverage]
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PWManagerDbContext>(options => options.UseSqlServer(Application.Registration.ConfigurationManager.CurrentDB));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }
    }
}
