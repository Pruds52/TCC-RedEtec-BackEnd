using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class GrupoMapping : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo");
            builder.HasKey(p => p.Id_Grupo);

            builder.Property(p => p.Id_Grupo).IsRequired();
            builder.Property(p => p.Id_Criador_Usuario);
            builder.Property(p => p.Nome_Grupo).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descricao_Grupo).HasMaxLength(50);
            builder.Property(p => p.Localizacao_Foto).HasMaxLength(255);
            builder.Property(p => p.Data_Criacao).IsRequired();
            builder.Property(p => p.Deletado_Grupo).IsRequired();

            builder.HasMany(p => p.Integrante_Grupos)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.Id_Grupo);

            builder.HasMany(p => p.Mensagem_Grupos)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.Id_Grupo);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Grupos)
                .HasForeignKey(p => p.Id_Criador_Usuario);
        }
    }

}
