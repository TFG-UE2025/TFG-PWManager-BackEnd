using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace TFG.PWManager.BackEnd.Application.Registration
{
    [ExcludeFromCodeCoverage]
    public static class ConfigurationManager
    {
        public static IConfiguration? Configuration { get; set; }

        public static bool IsFunction
        {
            get
            {
                return Configuration != null && !string.IsNullOrEmpty(Configuration["IsFunction"]) && bool.Parse(Configuration["IsFunction"]);
            }
        }

        public static string Separator
        {
            get
            {
                return Configuration != null && !string.IsNullOrEmpty(Configuration["Separator"]) ? Configuration["Separator"] : ":";
            }
        }

        #region ConnectionStrings

        public static string PWManagerDB
        {
            get
            {
                return Configuration != null ? Configuration[$"ConnectionStrings:pwmanager"] : string.Empty;
            }
        }

        public static string LocalDB
        {
            get
            {
                return Configuration != null ? Configuration[$"ConnectionStrings:Local"] : string.Empty;
            }
        }

        #endregion ConnectionStrings

        #region WebAPI

        public static string WebAPIName
        {
            get
            {
                return Configuration != null ? Configuration[$"WebAPI{Separator}Name"] : string.Empty;
            }
        }

        public static string CurrentDB
        {
            get
            {
                if (IsFunction)
                    return Configuration != null ? Configuration[$"WebAPI{Separator}CurrentDB"] : string.Empty;
                else
                    return Configuration != null ? Configuration.GetConnectionString(Configuration[$"WebAPI{Separator}CurrentDB"]) : string.Empty;
            }
        }

        public static string SchemaDB
        {
            get
            {
                return Configuration != null ? Configuration[$"WebAPI{Separator}SchemaDB"] : string.Empty;
            }
        }

        public static string LongDateFormat
        {
            get
            {
                return Configuration != null ? Configuration[$"WebAPI{Separator}LongDateFormat"] : string.Empty;
            }
        }

        public static string ShortDateFormat
        {
            get
            {
                return Configuration != null ? Configuration[$"WebAPI{Separator}ShortDateFormat"] : string.Empty;
            }
        }

        #endregion WebAPI

        #region JwtSettings

        public static string JwtIssuer
        {
            get
            {
                return Configuration != null ? Configuration[$"JwtSettings{Separator}Issuer"] : string.Empty;
            }
        }

        public static string JwtKey
        {
            get
            {
                return Configuration != null ? Configuration[$"JwtSettings{Separator}Key"] : string.Empty;
            }
        }

        public static string JwtMinutes
        {
            get
            {
                return Configuration != null ? Configuration[$"JwtSettings{Separator}Minutes"] : string.Empty;
            }
        }

        public static string JwtAuthType
        {
            get
            {
                return Configuration != null ? Configuration[$"JwtSettings{Separator}AuthType"] : string.Empty;
            }
        }

        public static string JwtAudience
        {
            get
            {
                return Configuration != null ? Configuration[$"JwtSettings{Separator}Audience"] : string.Empty;
            }
        }

        #endregion JwtSettings

        #region Swagger

        public static string SwaggerEnabled
        {
            get
            {
                return Configuration != null ? Configuration[$"Swagger{Separator}Enabled"] : string.Empty;
            }
        }

        #endregion Swagger

    }
}
