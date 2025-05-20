using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entity.Dtos.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Utilities.Jwt
{


    public class GenerateTokenJwt
    {
        private IConfiguration _configuration;
        public GenerateTokenJwt(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public async Task<AuthDto> GeneradorToken(int id)
        {
            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddHours(1);

            var tokenSeguridad = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenSeguridad);

            return new AuthDto 
            {
                Token = token,
                Expiracion = expiracion
            };
        } 

    }   
}