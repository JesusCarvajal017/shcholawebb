using Entity.ConfigModels.global;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels
{
    internal class ModuleFormConfig : IEntityTypeConfiguration<ModuleForm>
    {
        public void Configure(EntityTypeBuilder<ModuleForm> builder)
        {
            builder.ToTable("moduleForm", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.ModuleId)
                .HasColumnName("module_id")
                .IsRequired();
            builder.Property(p => p.FormId)
                .HasColumnName("form_id")
                .IsRequired();

            // Llave foraena
            builder.HasOne(ur => ur.Module)
               .WithMany(r => r.ModuleForm)
               .HasForeignKey(ur => ur.ModuleId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Form)
               .WithMany(r => r.ModuleForm)
               .HasForeignKey(ur => ur.FormId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

            //builder.HasData(
            //    new ModuleForm
            //    {
            //        Id = 1,
            //        ModuleId = 1,
            //        FormId = 1
            //    }
            //);

        }
    }
}
