namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class JwtResponseModel
    {
        public string? AccessToken { get; set; }

        public string? Email { get; set; }

        public string? ExpiredDate { get; set; }
    }
}
