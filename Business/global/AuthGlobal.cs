using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.factories;
using Data.interfaces.global;
using Entity.Dtos.Auth;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.global
{
    public class AuthGlobal 
    {
        protected readonly Auth _data;
        protected readonly ILogger<AuthGlobal> _logger;

        public AuthGlobal(IDataFactoryGlobal factory, ILogger<AuthGlobal> logger) 
        {
            _data = factory.CreateAuth();
            _logger = logger;
            
        }

        public async Task<Object> AuthApp(CredencialesDto login)
        {
            try
            {
                if (login == null)
                    throw new ExternalServiceException("Base de datos", $"acceso denegado:  {login.Email}");

                var updated = await _data.ValidarLoginAsync(login);

                if(updated == null)
                {
                    return new { message = "Acceso denegado, crendenciales incorrectas" };
                }
                

                return updated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al dar acceso {login.Email}");
                throw new ExternalServiceException("Base de datos", $"Error acceso no autorizado {login.Email}", ex);
            }
        }

    }
}
