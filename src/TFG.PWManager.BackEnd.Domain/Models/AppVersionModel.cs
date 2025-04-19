using TFG.PWManager.BackEnd.Domain.Commons;

namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class AppVersionModel : BaseModel
    {
        public string? AppName { get; set; }

        public string? Version { get; set; }
    }
}
