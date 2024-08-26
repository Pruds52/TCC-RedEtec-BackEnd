using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Mensagem_PrivadaMapping : IEntityTypeConfiguration<Mensagem_Privada>
    {
        public void Configure(EntityTypeBuilder<Mensagem_Privada> builder)
        {
            builder.HasKey(p => p.Id_Mensagem_Privada);

            builder.Property(p => p.Id_Mensagem_Privada).IsRequired();
            builder.Property(p => p.Id_Usuario_Emissor).IsRequired();
            builder.Property(p => p.Id_Usuario_Receptor).IsRequired();
            builder.Property(p => p.Mensagem).IsRequired();
            builder.Property(p => p.Localizacao_Midia);
            builder.Property(p => p.Data_Mensagem).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Mensagem_Privadas)
                .HasForeignKey(p => p.Id_Usuario_Emissor);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Mensagem_Privadas)
                .HasForeignKey(p => p.Id_Usuario_Receptor);

            builder.HasMany(p => p.Anexos)
                .WithOne(p => p.Mensagem_Privada)
                .HasForeignKey(p => p.Id_Mensagens_Privada);


        }
    }

}
