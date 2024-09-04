using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class ComentarioMapping : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(p => p.Id_Comentario);

            builder.Property(p => p.Id_Comentario).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Id_Postagem).IsRequired();
            builder.Property(p => p.Comentario_Postado).HasMaxLength(256);
            builder.Property(p => p.Data_Comentario);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasOne(p => p.Postagem)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(p => p.Id_Postagem);
        }
    }

}
