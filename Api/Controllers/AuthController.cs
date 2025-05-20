using Business.global;
using Business.service;
using Entity.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Utilities.Exeptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AuthGlobal _authBussines;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthGlobal authBussines,ILogger<AuthController> logger) 
        {
            _authBussines = authBussines;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Object), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidationUser([FromBody] CredencialesDto login)
        {
            try
            {
                var update = await _authBussines.AuthApp(login);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida el User con Name: {UserId} no tien acceso", login.Email);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "User no encontrado con ID: {UserId}", login.Email);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el User con ID: {UserId}", login.Email);
                return StatusCode(500, new { message = ex.Message });
            }
        }




    }
} 