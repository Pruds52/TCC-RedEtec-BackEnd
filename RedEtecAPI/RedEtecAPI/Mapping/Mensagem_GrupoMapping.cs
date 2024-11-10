using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Mensagem_GrupoMapping : IEntityTypeConfiguration<Mensagem_Grupo>
    {
        public void Configure(EntityTypeBuilder<Mensagem_Grupo> builder)
        {
            builder.ToTable("Mensagem_Grupo");
            builder.HasKey(p => p.Id_Mensagem_Grupo);

            builder.Property(p => p.Id_Mensagem_Grupo).IsRequired();
            builder.Property(p => p.Id_Grupo).IsRequired();
            builder.Property(p => p.Id_Usuario_Emissor).IsRequired();
            builder.Property(p => p.Mensagem).IsRequired();
            builder.Property(p => p.Localizacao_Arquivo);
            builder.Property(p => p.Data_Enviada).IsRequired();
            builder.Property(p => p.Deletado_Mensagem_Grupo).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Mensagem_Grupos)
                .HasForeignKey(p => p.Id_Usuario_Emissor);

            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Mensagem_Grupos)
                .HasForeignKey(p => p.Id_Grupo);

            builder.HasMany(p => p.Anexos)
                .WithOne(p => p.Mensagem_Grupo)
                .HasForeignKey(p => p.Id_Mensagem_Grupo);
        }
    }
}
