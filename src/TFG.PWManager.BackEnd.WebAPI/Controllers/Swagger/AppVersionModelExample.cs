using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.WebAPI.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class AppVersionModelExample : IExamplesProvider<AppVersionModel>
    {
        public AppVersionModel GetExamples()
        {
            return new AppVersionModel
            {
                AppName = Application.Registration.ConfigurationManager.WebAPIName,
                Version = "1.0"
            };
        }
    }
}
