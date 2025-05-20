using AutoMapper;
using Business.global;
using Data.factories;
using Entity.Dtos.RolFormPermission;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;


namespace Business.service
{
    public class RolFormPermissionBusiness : GenericBusiness<RolFormPermission, RolFormPermissionDto>
    {
        public RolFormPermissionBusiness(IDataFactoryGlobal factory, ILogger<RolFormPermission> logger, IMapper mapper) : base(factory.CreateRolFormPermissionData(), logger, mapper)
        {

        }

        public async Task<RolFormPermissionCreateDto> CreateAsync(RolFormPermissionCreateDto entityDto)
        {
            try
            {
                Validate(entityDto);
                var entity = _mapper.Map<RolFormPermission>(entityDto);
                var created = await _data.InsertAsync(entity);

                return _mapper.Map<RolFormPermissionCreateDto>(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear {entityDto.Id} permiso de formulario segun el rol");
                throw new ExternalServiceException("Base de datos", $"Error al crear {entityDto.Id} permiso de formulario segun el rol", ex);
            }
        }

        protected override void Validate(RolFormPermissionDto entity)
        {
            if (entity == null)
                throw new ValidationException("la entidad no puede ser nula.");
        }

        protected  void Validate(RolFormPermissionCreateDto entity)
        {
            if (entity == null)
                throw new ValidationException("la entidad no puede ser nula.");
        }
    }
}
