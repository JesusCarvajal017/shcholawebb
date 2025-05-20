using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    internal class RolFormPermissionConfig : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            builder.ToTable("rolFormPermission", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.RolId)
                .HasColumnName("rol_id")
                .IsRequired();
            builder.Property(p => p.FormId)
                .HasColumnName("form_id")
                .IsRequired();
            builder.Property(p => p.PermissionId)
                 .HasColumnName("permission_id")
                 .IsRequired();

            // Llave foraena
            builder.HasOne(ur => ur.Rol)
               .WithMany(r => r.RolFormPermission)
               .HasForeignKey(ur => ur.RolId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Form)
               .WithMany(r => r.RolFormPermission)
               .HasForeignKey(ur => ur.FormId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Permission)
                .WithMany(r => r.RolFormPermission)
                .HasForeignKey(ur => ur.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

           // builder.HasData(
           //    new RolFormPermission
           //    {
           //        Id = 1,
           //        RolId = 1,
           //        FormId = 1,
           //        PermissionId = 1
           //    }
           //);

        }
    }
}
