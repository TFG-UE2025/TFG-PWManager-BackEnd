using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TFG.PWManager.BackEnd.WebAPI.Registration
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var enabled = Convert.ToBoolean(Application.Registration.ConfigurationManager.SwaggerEnabled);

            if (enabled)
            {
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = Application.Registration.ConfigurationManager.WebAPIName,
                        Description = $"API que maneja el dominio de {Application.Registration.ConfigurationManager.WebAPIName}"
                    });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                    options.ExampleFilters();
                    options.CustomSchemaIds(type => type.ToString());
                });

                services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
                services.AddFluentValidationRulesToSwagger();
            }

            return services;
        }
    }
}
