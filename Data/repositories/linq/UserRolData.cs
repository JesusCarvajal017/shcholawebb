using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.helpers;

namespace Data.repositories.linq
{
    public class UserRolData : GenericData<UserRol>
    {

        private AplicationDbContext context;
        private ILogger<UserRol> logger;
        public UserRolData(AplicationDbContext context, ILogger<UserRol> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public override async Task<IEnumerable<UserRol>> QueryAllAsyn()
        {
            try
            {
                return await context.UserRol
                    .Include(ur => ur.User)
                    .Include(ur => ur.Rol)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error obtener los roles del usuario");
                throw;
            }
        }

        public override async Task<UserRol> QueryById(int id)
        {
            try
            {
                return await context.Set<UserRol>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Rol)
                    .FirstOrDefaultAsync(ur => ur.Id == id);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error obtener los roles del usuario {id}");
                throw;
            }
        }

   
    }
}
