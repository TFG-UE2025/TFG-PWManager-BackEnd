using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TFG.PWManager.BackEnd.Application.Registration;
using TFG.PWManager.BackEnd.Business.Registration;
using TFG.PWManager.BackEnd.WebAPI.Builders;
using TFG.PWManager.BackEnd.WebAPI.Handlers;
using TFG.PWManager.BackEnd.WebAPI.Middleware.CurrentUser;
using TFG.PWManager.BackEnd.WebAPI.Middleware.HttpResponseException;
using TFG.PWManager.BackEnd.WebAPI.Registration;
using ConfigurationManager = TFG.PWManager.BackEnd.Application.Registration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
    });
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddBusinessServices();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerServices();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuers = new List<string>() { ConfigurationManager.JwtIssuer },
            ValidAudiences = new List<string>() { ConfigurationManager.JwtAudience },
            IssuerSigningKeys = new List<SecurityKey>()
            {
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.JwtKey))
            },
            AuthenticationType = ConfigurationManager.JwtAuthType
        };
    });




//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<HttpResponseExceptionMiddleware>();
app.UseMiddleware<CurrentUserMiddleware>();

app.AddSwaggerApp();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();



//app.MapControllers();

app.Run();
