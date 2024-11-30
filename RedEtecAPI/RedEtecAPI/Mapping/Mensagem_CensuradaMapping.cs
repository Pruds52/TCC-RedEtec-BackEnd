using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Mensagem_CensuradaMapping : IEntityTypeConfiguration<Mensagem_Censurada>
    {
        public void Configure(EntityTypeBuilder<Mensagem_Censurada> builder)
        {
            builder.ToTable("Mensagem_Censuarada");
            builder.HasKey(p => p.Id_Mensagem_Censurada);

            builder.Property(p => p.Id_Mensagem_Censurada).IsRequired();
            builder.Property(p => p.Id_Usuario_Emissor).IsRequired();
            builder.Property(p => p.Id_Usuario_Receptor).IsRequired();
            builder.Property(p => p.Id_Grupo).IsRequired();
            builder.Property(p => p.Mensagem).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Data_Enviada).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Mensagem_Censuradas)
                .HasForeignKey(p => p.Id_Usuario_Emissor);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Mensagem_Censuradas)
                .HasForeignKey(p => p.Id_Usuario_Receptor);

            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Mensagem_Censuradas)
                .HasForeignKey(p => p.Id_Grupo);
        }
    }
}
