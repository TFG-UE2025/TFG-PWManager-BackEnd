namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class UserKeyModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? PasswordHash { get; set; }
    }
}
