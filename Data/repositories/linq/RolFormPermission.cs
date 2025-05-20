using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.helpers;

namespace Data.repositories.linq
{
    public class RolFormPermissionData : GenericData<RolFormPermission>
    {

        private AplicationDbContext context;
        private ILogger<RolFormPermission> logger;
        public RolFormPermissionData(AplicationDbContext context, ILogger<RolFormPermission> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public override async Task<IEnumerable<RolFormPermission>> QueryAllAsyn()
        {
            try
            {
                return await context.RolFormPermission
                    .Include(ur => ur.Rol)
                    .Include(ur => ur.Form)
                    .Include(ur => ur.Permission)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error obtener los permisos del formularios");
                throw;
            }
        }

        public override async Task<RolFormPermission> QueryById(int id)
        {
            try
            {
                return await context.Set<RolFormPermission>()
                    .Include(ur => ur.Rol)
                    .Include(ur => ur.Form)
                    .Include(ur => ur.Permission)
                    .FirstOrDefaultAsync(ur => ur.Id == id);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error al traer una Forma por id {id}");
                throw;
            }
        }

   
    }
}
