using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.helpers;

namespace Data.repositories.linq
{
    public class UserData : GenericData<User>
    {

        private AplicationDbContext context;
        private ILogger<User> logger;
        public UserData(AplicationDbContext context, ILogger<User> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }         

        public override async Task<IEnumerable<User>> QueryAllAsyn()
        {
            try
            {
                return await context.User
                    .Include(ur => ur.Person)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving UserRols");
                throw;
            }
        }

        public override async Task<User> InsertAsync(User entity)
        {
            try
            {
                // encriptamos la contraseña
                entity.Password = HashPassword.EncriptPassword(entity.Password);

                await context.Set<User>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"registro de usuario denegado:  {entity}");
                throw;
            }
        }





    }
}
