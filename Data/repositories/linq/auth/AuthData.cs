using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.interfaces.global;
using Entity.Context;
using Entity.Dtos.Auth;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Jwt;

namespace Data.repositories.linq.auth
{
    public class AuthData : Auth
    {
        private AplicationDbContext _contenxt;
        private ILogger<AuthData> _logger;
        private readonly GenerateTokenJwt _jwt;

        public AuthData(AplicationDbContext context, ILogger<AuthData> logger, GenerateTokenJwt jwt) 
        {
            _contenxt = context;
            _logger = logger;
            _jwt = jwt;
        }

        public async Task<AuthDto> ValidarLoginAsync(CredencialesDto credenciales) 
        {
            //busqueda del usuario por nombre
            var user = await _contenxt.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == credenciales.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(credenciales.Password, user.Password))
            {
                var token = await _jwt.GeneradorToken(user.Id);

                return token;
                //return token;
            }

            return null;
        }


    }
}
