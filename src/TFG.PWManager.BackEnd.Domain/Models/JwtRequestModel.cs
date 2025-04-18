using System.Security.Claims;

namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class JwtRequestModel
    {
        public string? Email { get; set; }

        public string? SecretKey { get; set; }

        public string? Issuer { get; set; }

        public string? Audience { get; set; }

        public double ExpirationMinutes { get; set; }

        public string? TzId { get; set; }

        public List<Claim>? Claims { get; set; }
    }
}
