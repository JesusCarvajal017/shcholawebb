using Entity.Model.global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.global
{
    public static class ExtendsModelLongs
    {
        public static void MapBaseModel<T>(this EntityTypeBuilder<T> builder) where T : IModel
        {
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.DeletedAt).HasColumnName("deleted_at");
            builder.Property(p => p.Status)
                .HasColumnName("status")
                .IsRequired();
        }
        
    }
}
