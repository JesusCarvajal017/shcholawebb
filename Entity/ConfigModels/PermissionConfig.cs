using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired();

            builder.MapBaseModel();

            builder.HasData(
                new Permission
                {
                    Id = 1,
                    Name = "system complete",
                    Description = "Formulario de inicio"
                }
            );
        }
    }
}
