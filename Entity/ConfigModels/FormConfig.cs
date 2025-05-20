using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    public class FormConfig : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("form", schema: "security");

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
                new Form
                {
                    Id = 1,
                    Name = "Usuarios",
                    Description = "Módulo de gestión de usuarios"
                }
            );
        }
    }
}
