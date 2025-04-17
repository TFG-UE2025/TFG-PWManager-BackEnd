using System.Net;
using System.Text.Json;
using TFG.PWManager.BackEnd.Domain.Exceptions;

namespace TFG.PWManager.BackEnd.WebAPI.Middleware.HttpResponseException
{
    public class HttpResponseExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public HttpResponseExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var result = string.Empty;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                int statusCode;
                var customCodes = new List<string>();

                switch (ex)
                {
                    case ValidationException validationException:
                        statusCode = StatusCodes.Status400BadRequest;
                        var json = JsonSerializer.Serialize(validationException.Errors, options);
                        customCodes = validationException.CustomCodes.ToList();
                        result = JsonSerializer.Serialize(new HttpResponseException((HttpStatusCode)statusCode, $"{ex.Message}: {json}", customCodes), options);
                        break;

                    case NotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        break;

                    case BadRequestException:
                        statusCode = StatusCodes.Status400BadRequest;
                        break;

                    case UnauthorizedException:
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;

                    case PreconditionFailedException:
                        statusCode = StatusCodes.Status412PreconditionFailed;
                        break;

                    case ForbiddenException:
                        statusCode = StatusCodes.Status403Forbidden;
                        break;

                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                string message = string.Concat(ex.GetType().Name, " - ", ex.Message);
                if (ex.InnerException != null)
                    message = string.Concat(message, ex.InnerException.Message);

                if (string.IsNullOrEmpty(result))
                {
                    var response = _env.IsDevelopment() ? new HttpResponseException((HttpStatusCode)statusCode, message)
                        : new HttpResponseException((HttpStatusCode)statusCode, ex.Message);

                    result = JsonSerializer.Serialize(response, options);
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
                await _next(context);
            }
        }
    }
}
