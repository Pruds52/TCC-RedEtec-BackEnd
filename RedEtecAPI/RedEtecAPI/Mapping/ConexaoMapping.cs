using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class ConexaoMapping : IEntityTypeConfiguration<Conexao>
    {
        public void Configure(EntityTypeBuilder<Conexao> builder)
        {
            builder.HasKey(p => p.Id_Conexao);

            builder.Property(p => p.Id_Conexao).IsRequired();
            builder.Property(p => p.Solicitacao_Enviada).IsRequired();
            builder.Property(p => p.Solicitacao_Solicitada).IsRequired();
            builder.Property(p => p.Data_Conexao).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Conexoes)
                .HasForeignKey(p => p.Solicitacao_Enviada);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Conexoes)
                .HasForeignKey(p => p.Solicitacao_Solicitada);
        }
    }

}
