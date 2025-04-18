
namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class ConfigAuditUserKeyModel
    {
        public bool UseRegex { get; set; }
        public int ExpiredKeyInDays { get; set; }
    }
}
