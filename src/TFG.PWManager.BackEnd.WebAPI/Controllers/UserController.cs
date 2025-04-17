using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using TFG.PWManager.BackEnd.Domain.Contracts.Services;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.WebAPI.Controllers.Swagger;
using TFG.PWManager.BackEnd.WebAPI.Middleware.HttpResponseException;

namespace TFG.PWManager.BackEnd.WebAPI.Controllers
{
    /// <summary>
    /// Se encarga de la gestión de los usuarios
    /// </summary>
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Obtiene un usuario filtrando por su identificador
        /// </summary>
        /// <param name="userId">Identificador del usuario</param>
        /// <returns>Usuario</returns>
        /// <response code="200">Operación ejecutada con éxito.</response>
        /// <response code="401">Se lanzará esta respuesta cuando la autorización haya sido denegada.</response>
        /// <response code="403">Se lanzará esta respuesta cuando el acceso al recurso esté prohibido.</response>
        /// <response code="404">Se lanzará esta respuesta cuando los datos de la request no hayan sido encontrados.</response>
        /// <response code="500">Se lanzará esta respuesta cuando el servidor sea incapaz de procesar la petición.</response>
        /// <response code="503">Se lanzará esta respuesta cuando el servicio no esté disponible.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserModelExample))]
        [Produces("application/json")]
        [HttpGet]
        [Authorize]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            return Ok(await _userService.GetByIdAsync(userId));
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Identificador del usuario</returns>
        /// <response code="200">Operación ejecutada con éxito.</response>
        /// <response code="400">Se lanzará esta respuesta cuando los datos de la request no sean correctos.</response>
        /// <response code="401">Se lanzará esta respuesta cuando la autorización haya sido denegada.</response>
        /// <response code="403">Se lanzará esta respuesta cuando el acceso al recurso esté prohibido.</response>
        /// <response code="500">Se lanzará esta respuesta cuando el servidor sea incapaz de procesar la petición.</response>
        /// <response code="503">Se lanzará esta respuesta cuando el servicio no esté disponible.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            return Ok(await _userService.CreateUser(user));
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="userId">Identificador del usuario</param>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Identificador del usuario</returns>
        /// <response code="200">Operación ejecutada con éxito.</response>
        /// <response code="400">Se lanzará esta respuesta cuando los datos de la request no sean correctos.</response>
        /// <response code="401">Se lanzará esta respuesta cuando la autorización haya sido denegada.</response>
        /// <response code="403">Se lanzará esta respuesta cuando el acceso al recurso esté prohibido.</response>
        /// <response code="404">Se lanzará esta respuesta cuando los datos de la request no hayan sido encontrados.</response>
        /// <response code="500">Se lanzará esta respuesta cuando el servidor sea incapaz de procesar la petición.</response>
        /// <response code="503">Se lanzará esta respuesta cuando el servicio no esté disponible.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [Produces("application/json")]
        [HttpPut]
        [Authorize]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UserModel user)
        {
            return Ok(await _userService.UpdateUser(userId, user));
        }

        /// <summary>
        /// Actualiza el password de un usuario existente
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Identificador del usuario</returns>
        /// <response code="200">Operación ejecutada con éxito.</response>
        /// <response code="400">Se lanzará esta respuesta cuando los datos de la request no sean correctos.</response>
        /// <response code="401">Se lanzará esta respuesta cuando la autorización haya sido denegada.</response>
        /// <response code="403">Se lanzará esta respuesta cuando el acceso al recurso esté prohibido.</response>
        /// <response code="404">Se lanzará esta respuesta cuando los datos de la request no hayan sido encontrados.</response>
        /// <response code="500">Se lanzará esta respuesta cuando el servidor sea incapaz de procesar la petición.</response>
        /// <response code="503">Se lanzará esta respuesta cuando el servicio no esté disponible.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [Produces("application/json")]
        [HttpPut]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> ChangePasswordUser([FromBody] UserModel user)
        {
            return Ok(await _userService.ChangeUserPassword(user.PasswordHash!, user.Email!));
        }

        /// <summary>
        /// Elimina un usuario existente
        /// </summary>
        /// <param name="userId">Identificador del usuario</param>
        /// <returns>Identificador del usuario</returns>
        /// <response code="200">Operación ejecutada con éxito.</response>
        /// <response code="400">Se lanzará esta respuesta cuando los datos de la request no sean correctos.</response>
        /// <response code="401">Se lanzará esta respuesta cuando la autorización haya sido denegada.</response>
        /// <response code="403">Se lanzará esta respuesta cuando el acceso al recurso esté prohibido.</response>
        /// <response code="404">Se lanzará esta respuesta cuando los datos de la request no hayan sido encontrados.</response>
        /// <response code="500">Se lanzará esta respuesta cuando el servidor sea incapaz de procesar la petición.</response>
        /// <response code="503">Se lanzará esta respuesta cuando el servicio no esté disponible.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpResponseException))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(HttpResponseException))]
        [Produces("application/json")]
        [HttpDelete]
        [Authorize]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            return Ok(await _userService.DeleteUser(userId));
        }
    }


}
