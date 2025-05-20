using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    public class ModuleConfig : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("module" , schema: "security");

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
                new Module
                {
                    Id = 1,
                    Name = "Seguridad",
                    Description = "Todo el tema de permisos del sistema"
                }
            );

        }
    }
}
