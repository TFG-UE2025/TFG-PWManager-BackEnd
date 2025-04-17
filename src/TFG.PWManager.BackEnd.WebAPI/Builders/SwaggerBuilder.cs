using System.Diagnostics.CodeAnalysis;

namespace TFG.PWManager.BackEnd.WebAPI.Builders
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerBuilder
    {
        public static IApplicationBuilder AddSwaggerApp(this IApplicationBuilder app)
        {
            var enabled = Convert.ToBoolean(Application.Registration.ConfigurationManager.SwaggerEnabled);

            if (enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
