using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.global;
using Data.factories;
using Entity.Dtos.RolFormPermission;
using Entity.Dtos.UserRol;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.service
{
    public class UserRolBusiness : GenericBusiness<UserRol, UserRolDto>
    {
        public UserRolBusiness(IDataFactoryGlobal factory, ILogger<UserRol> logger, IMapper mapper) : base(factory.CreateUserRolData(), logger, mapper)
        {

        }

        public async Task<UserRolCreateDtos> CreateAsync(UserRolCreateDtos entityDto)
        {
            try
            {
                Validate(entityDto);
                var entity = _mapper.Map<UserRol>(entityDto);
                var created = await _data.InsertAsync(entity);

                return _mapper.Map<UserRolCreateDtos>(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear {entityDto.Id} permiso de formulario segun el rol");
                throw new ExternalServiceException("Base de datos", $"Error al crear {entityDto.Id} permiso de formulario segun el rol", ex);
            }
        }


        protected override void Validate(UserRolDto entity)
        {
            if (entity == null)
                throw new ValidationException("la entidad no puede ser nula.");
        }

        protected void Validate(UserRolCreateDtos entity)
        {
            if (entity == null)
                throw new ValidationException("la entidad no puede ser nula.");
        }

    }
}
