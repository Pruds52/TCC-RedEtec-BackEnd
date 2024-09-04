using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class NotificacaoMapping : IEntityTypeConfiguration<Notificacao>
    {
        public void Configure(EntityTypeBuilder<Notificacao> builder)
        {
            builder.ToTable("Notificacao");
            builder.HasKey(p => p.Id_Notificacao);

            builder.Property(p => p.Id_Notificacao).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Tipo_Notificacao).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Mensagem_Notificacao).IsRequired();
            builder.Property(p => p.Data_Notificacao).IsRequired();
            builder.Property(p => p.Lida_Notificacao);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Notificacoes)
                .HasForeignKey(p => p.Id_Usuario);
        }
    }
}
