using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.UserName)
                .HasColumnName("user_name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(p => p.Password)
               .HasColumnName("password")
               .HasColumnType("text")
               .IsRequired();
            builder.Property(p => p.PersonId)
                 .HasColumnName("person_id")
                 .IsUnicode()
                 .IsRequired();

            builder.MapBaseModel();

            builder.HasIndex(p => p.PersonId)
                    .IsUnique();

            builder.HasOne(p => p.Person)
               .WithOne() 
               .HasForeignKey<User>(p => p.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
