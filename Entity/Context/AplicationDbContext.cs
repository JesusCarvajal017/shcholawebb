using Entity.ConfigModels;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entity.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options ) : base (options)
        {
                    
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserRol> UserRol { get; set; }
        public DbSet<ModuleForm> ModuleForm { get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica tu configuración que implementen IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new ModuleConfig());
            modelBuilder.ApplyConfiguration(new FormConfig());

            modelBuilder.ApplyConfiguration(new UserRolConfig());
            modelBuilder.ApplyConfiguration(new ModuleFormConfig());
            modelBuilder.ApplyConfiguration(new RolFormPermissionConfig());


            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationDbContext).Assembly);
        }


    }
}
