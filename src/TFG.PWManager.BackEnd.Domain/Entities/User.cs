
namespace TFG.PWManager.BackEnd.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? DisplayName { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public bool ActiveChk { get; set; }

        public int LanguageId { get; set; }

        public Language? Language { get; set; }
    }
}
