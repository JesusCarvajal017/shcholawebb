using Business.global;
using Business.service;
using Entity.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Utilities.Exeptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AuthGlobal _authBusiness;
        private readonly PersonBussines _personBusiness;
        private readonly UserBusiness _userBusinesss;
        private readonly ILogger<AuthController> _logger;

        public AuthController
            (
                AuthGlobal authBussines,
                ILogger<AuthController> logger,
                PersonBussines personBusiness,
                UserBusiness userBusiness
            ) 
        {
            _authBusiness = authBussines;
            _personBusiness = personBusiness;
            _userBusinesss = userBusiness;
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
                var update = await _authBusiness.AuthApp(login);
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