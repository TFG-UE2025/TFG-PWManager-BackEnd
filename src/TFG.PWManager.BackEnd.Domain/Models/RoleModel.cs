using Swashbuckle.AspNetCore.Annotations;

namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [SwaggerSchema(Description = "Maximum length: 256")]
        public string? Name { get; set; }

        [SwaggerSchema(Description = "Maximum length: 256")]
        public string? Description { get; set; }
    }
}
