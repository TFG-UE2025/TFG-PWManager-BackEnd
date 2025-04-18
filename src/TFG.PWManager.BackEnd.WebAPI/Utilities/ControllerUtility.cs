using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.WebAPI.Utilities
{
    /// <summary>
    /// Utilidades auxiliares para controladores.
    /// </summary>
    public static class ControllerUtility
    {

        /// <summary>
        /// Extrae las credenciales codificadas en base64 del encabezado Authorization.
        /// Este método está pensado para autenticación básica (Basic Auth).
        /// </summary>
        /// <param name="context">Contexto del controlador que contiene la solicitud HTTP.</param>
        /// <returns>Un arreglo de strings con el usuario y la contraseña.</returns>
        public static string[] GetCredentials(ControllerContext context)
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
            var base64 = authHeader != null && authHeader.Parameter != null ? authHeader.Parameter : string.Empty;
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64)).Split(':');
            return credentials;
        }

        /// <summary>
        /// Obtiene la información del token (usuario, correo, idioma, roles) desde el contexto del controlador.
        /// </summary>
        /// <param name="context">Contexto del controlador que contiene el usuario autenticado.</param>
        /// <returns>Una instancia de <see cref="TokenInfoModel"/> con los datos del usuario.</returns>
        public static TokenInfoModel GetTokenInfo(ControllerContext context)
        {
            var userId = context.HttpContext.User.FindFirstValue("uid");
            var langCode = context.HttpContext.User.FindFirstValue("langcode");
            var email = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var roles = context.HttpContext.User.FindAll(ClaimTypes.Role).Select(yu => yu.Value.ToString());

            return new TokenInfoModel()
            {
                UserId = userId,
                Email = email,
                LanguageCode = langCode,
                RoleId = roles
            };
        }
    }
}
