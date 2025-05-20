using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Entity.Seeding
{
    public static class SeedService
    {
        public static void Initialize(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AplicationDbContext>();

            SeedUser(context);
            SeedUserRol(context);
            SeedRolFormPermission(context);
            SeedModuleForm(context);
        }

        private static void SeedUser(AplicationDbContext context)
        {
            if (!context.User.Any())
            {
                context.User.Add(new User
                {
                    Id = 1,
                    UserName = "Yisus017",
                    Email = "example@gmail.com",
                    Password = "12345",
                    PersonId = 1,
                    Status = 1
                });
                context.SaveChanges();
            }
        }

        private static void SeedUserRol(AplicationDbContext context)
        {
            if (!context.UserRol.Any())
            {
                context.UserRol.Add(new UserRol
                {
                    Id = 1,
                    UserId = 1,
                    RolId = 1,
                });
                context.SaveChanges();
            }
        }

        private static void SeedRolFormPermission(AplicationDbContext context)
        {
            if (!context.RolFormPermission.Any())
            {
                context.RolFormPermission.Add(new RolFormPermission
                {
                    Id = 1,
                    RolId = 1,
                    FormId = 1,
                    PermissionId = 1
                });
                context.SaveChanges();
            }
        }

        private static void SeedModuleForm(AplicationDbContext context)
        {
            if (!context.ModuleForm.Any())
            {
                context.ModuleForm.Add(new ModuleForm
                {
                    Id = 1,
                    ModuleId = 1,
                    FormId = 1,
                });
                context.SaveChanges();
            }
        }
    }
}

