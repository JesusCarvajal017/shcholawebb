using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Identification)
               .HasColumnName("identification")
               .IsRequired();
            builder.Property(p => p.Status)
                 .HasColumnName("age")
                 .IsRequired();

            builder.MapBaseModel();


            builder.HasData(
                new Person
                {
                    Id = 1,
                    Name = "Jesus",
                    LastName = "Carvajal",
                    Identification = 1076503110,
                    Age = 19
                }

            );

        }
    }
}
