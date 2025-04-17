namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class TokenInfoModel
    {
        public string? UserId { get; set; }

        public string? Email { get; set; }

        public string? LanguageCode { get; set; }

        public IEnumerable<string>? RoleId { get; set; }
    }
}
