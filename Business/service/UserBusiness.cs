using AutoMapper;
using Business.global;
using Data.factories;
using Entity.Dtos.User;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;


namespace Business.service
{
    public class UserBusiness : GenericBusiness<User, UserDto>
    {
        public UserBusiness(IDataFactoryGlobal factory, ILogger<User> logger, IMapper mapper) : base(factory.CreateUserData(), logger, mapper)
        {

        }

        protected override void Validate(UserDto person)
        {
            if (person == null)
                throw new ValidationException("El formulario no puede ser nulo.");
        }
    }
}
