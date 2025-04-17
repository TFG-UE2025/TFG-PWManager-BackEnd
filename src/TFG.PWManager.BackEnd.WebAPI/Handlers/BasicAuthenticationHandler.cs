using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace TFG.PWManager.BackEnd.WebAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder enconder, ISystemClock clock)
            : base(options, logger, enconder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var credentials = GetCredentials();
                var username = credentials[0];
                var password = credentials[1];

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (Exception ex)
            {
                return Task.FromResult(AuthenticateResult.Fail($"Authentication failed: {ex.Message}"));
            }
        }

        private string[] GetCredentials()
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var base64 = authHeader != null && authHeader.Parameter != null ? authHeader.Parameter : string.Empty;
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64)).Split(':');
            return credentials;
        }
    }
}
