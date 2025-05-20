using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Data.repositories.linq
{
    public class DataPerson : GenericData<Person>
    {
        public DataPerson(AplicationDbContext context, ILogger<Person> logger) : base(context, logger)
        {

        }
    }
}
