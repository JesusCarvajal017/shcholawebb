using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.repositories.linq.auth;
using Entity.Dtos.Auth;

namespace Data.interfaces.Auth
{
    public interface IAuth
    {
       public Task<AuthDto> ValidarLoginAsync(CredencialesDto credenciales);
    }
}
