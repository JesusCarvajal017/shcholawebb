using AutoMapper;
using Business.global;
using Data.factories;
using Entity.Dtos;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.service
{
    public class PersonBussines : GenericBusiness<Person, PersonDto>
    {
        public PersonBussines(IDataFactoryGlobal factory, ILogger<Person> logger, IMapper mapper) : base(factory.CreatePersonData(), logger, mapper)
        {

        }

        protected override void Validate(PersonDto person)
        {
            if (person == null)
                throw new ValidationException("El formulario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(person.Name))
                throw new ValidationException("El título del formulario es obligatorio.");
        }

    }
}
