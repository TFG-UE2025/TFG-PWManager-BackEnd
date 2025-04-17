using System.Net;

namespace TFG.PWManager.BackEnd.WebAPI.Middleware.HttpResponseException
{
    public class HttpResponseException
    {
        public HttpResponseException(HttpStatusCode statusCode, string message, List<string>? customCodes = null)
        {
            StatusCode = (int)statusCode;
            Message = message;
            CustomCodes = customCodes ?? new List<string>();
        }

        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;

        public string Message { get; set; }

        public List<string> CustomCodes { get; set; }
    }
}
