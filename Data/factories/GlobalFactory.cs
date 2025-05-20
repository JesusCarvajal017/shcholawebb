using Data.interfaces.global;
using Data.repositories.linq;
using Data.repositories.linq.auth;
using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities.Jwt;

namespace Data.factories
{
    public class GlobalFactory : IDataFactoryGlobal
    {
        private readonly AplicationDbContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfiguration _configuration;
        private readonly GenerateTokenJwt _jwt;

        public GlobalFactory(AplicationDbContext context, ILoggerFactory loggerFactory, IConfiguration configuracion, GenerateTokenJwt jwt)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _configuration = configuracion;
            _jwt = jwt;
        }
        public CrudGeneric<Person> CreatePersonData()
        {
            var logger = _loggerFactory.CreateLogger<Person>();
            return new DataPerson(_context, logger);
        }

        public CrudGeneric<User> CreateUserData()
        {
            var logger = _loggerFactory.CreateLogger<User>();
            return new UserData(_context, logger);
        }

        public CrudGeneric<RolFormPermission> CreateRolFormPermissionData()
        {
            var logger = _loggerFactory.CreateLogger<RolFormPermission>();
            return new RolFormPermissionData(_context, logger);
        }

        public Auth CreateAuth()
        {
            var logger = _loggerFactory.CreateLogger<AuthData>();
            return new AuthData(_context, logger, _jwt);
        }

    }
}