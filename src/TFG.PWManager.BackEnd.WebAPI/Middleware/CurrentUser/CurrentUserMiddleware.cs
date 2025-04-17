using System.Security.Claims;
using TFG.PWManager.BackEnd.Domain.Custom;
using TFG.PWManager.BackEnd.Domain.Enums;

namespace TFG.PWManager.BackEnd.WebAPI.Middleware.CurrentUser
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, CurrentUserProvider currentUserProvider)
        {
            var existsAuthorization = context.Request.Headers.TryGetValue("Authorization", out var token);

            if (existsAuthorization)
            {
                var isBasic = token.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase);

                string userId = isBasic ? "0" : context.User.FindFirstValue("uid");
                var email = isBasic ? context.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value.ToString() :
                    context.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value.ToString();
                IEnumerable<string> roleId = from yu in context.User.FindAll("http://schemas.microsoft.com/ws/2008/06/identity/claims/role") select yu.Value.ToString();

                var userToken = CheckToken(token);
                var existsTimeZoneId = context.Request.Headers.TryGetValue("x-timezone", out var timeZoneId);

                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(email))
                {
                    timeZoneId = existsTimeZoneId ? timeZoneId : DateTimeEnum.Utc;
                    currentUserProvider.SetCurrentUser(userId, email!, roleId, userToken, timeZoneId);
                }
            }

            await _next(context);
        }

        private static string CheckToken(string token)
        {
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return token![7..];
            }
            else if (token.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return token![6..];
            }

            return string.Empty;
        }

    }
}
