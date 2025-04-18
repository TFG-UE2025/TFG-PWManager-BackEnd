using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.WebAPI.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class TokenModelExample : IExamplesProvider<TokenModel>
    {
        public TokenModel GetExamples()
        {
            return new TokenModel
            {
                AccessToken = "eyfagfegrwgrggre.eydwefwegwegggdsa",
                Email = "admin@admin.com",
                ExpiredDate = "10/01/2022 14:00:00.000"
            };
        }
    }
}
