using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.WebAPI.Controllers.Swagger;
using TFG.PWManager.BackEnd.WebAPI.Middleware.HttpResponseException;

namespace TFG.PWManager.BackEnd.WebAPI.Controllers
{
    /// <summary>
    /// Se encarga de la obtención del estado de conectividad del Api
    /// </summary>
    [ApiController]
    [Route("healthcheck")]
    [ExcludeFromCodeCoverage]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Obtiene datos sobre la versión del Api
        /// </summary>
        /// <returns>Objeto con nombre del Api y su versión</returns>
        /// <include file='docs_tags.xml' path='docs/tags[@name="healthcheck"]/*' />
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppVersionModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AppVersionModelExample))]
        [Produces("application/json")]
        [HttpGet]
        [AllowAnonymous]
        [Route("version")]
        public IActionResult GetAppVersion()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string resultVersion = $"{currentVersion?.Major}.{currentVersion?.Minor}.{currentVersion?.Build}.{currentVersion?.Revision}";

            return Ok(new AppVersionModel()
            {
                AppName = Application.Registration.ConfigurationManager.WebAPIName,
                Version = resultVersion,
            });
        }
    }
}
