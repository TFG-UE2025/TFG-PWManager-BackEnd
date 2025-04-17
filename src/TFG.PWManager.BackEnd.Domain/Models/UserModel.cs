using Swashbuckle.AspNetCore.Annotations;

namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [SwaggerSchema(Description = "Maximum length: 30")]
        public string? DisplayName { get; set; }         

        [SwaggerSchema(Description = "Maximum length: 100")]
        public string? Name { get; set; }

        [SwaggerSchema(Description = "Maximum length: 100")]
        public string? Surname { get; set; }

        [SwaggerSchema(Description = "Maximum length: 20")]
        public string? PhoneNumber { get; set; }

        [SwaggerSchema(Description = "Maximum length: 256")]
        public string? Email { get; set; }

        [SwaggerSchema(Description = "No maximum size")]
        public string? PasswordHash { get; set; }

        public bool ActiveChk { get; set; }

        public int? LanguageId { get; set; }

        [SwaggerSchema(Description = "Maximum length: 6")]
        public string? LanguageCode { get; set; }

        public DateTime? PasswordExpiredDate { get; set; }
    }
}
