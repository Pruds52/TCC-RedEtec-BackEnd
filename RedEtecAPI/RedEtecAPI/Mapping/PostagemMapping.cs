using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class PostagemMapping : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(p => p.Id_Postagem);

            builder.Property(p => p.Id_Postagem).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Legenda_Postagem);
            builder.Property(p => p.Localizacao_Midia_Postagem).HasMaxLength(256);
            builder.Property(p => p.Data_Postagem).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Postagens)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasMany(p => p.Curtidas)
                .WithOne(p => p.Postagem)
                .HasForeignKey(p => p.Id_Postagem);

            builder.HasMany(p => p.Comentarios)
               .WithOne(p => p.Postagem)
               .HasForeignKey(p => p.Id_Postagem);

            builder.HasMany(p => p.Anexos)
                .WithOne(p => p.Postagem)
                .HasForeignKey(p => p.Id_Postagem);
        }
    }

}
