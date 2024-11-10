using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class AnexoMapping : IEntityTypeConfiguration<Anexo>
    {
        public void Configure(EntityTypeBuilder<Anexo> builder)
        {
            builder.ToTable("Anexo");
            builder.HasKey(p => p.Id_Anexo);

            builder.Property(p => p.Id_Anexo).IsRequired();
            builder.Property(p => p.Id_Postagem);
            builder.Property(p => p.Id_Mensagem_Grupo);
            builder.Property(p => p.Nome_Arquivo).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Tipo_Anexo).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Caminho_Anexo).IsRequired().HasMaxLength(255);
            builder.Property(p => p.DataAnexo).IsRequired();
            builder.Property(p => p.Deletado_Anexo).IsRequired();

            builder.HasOne(p => p.Postagem)
                .WithMany(p => p.Anexos)
                .HasForeignKey(p => p.Id_Postagem);

            builder.HasOne(p => p.Mensagem_Grupo)
                .WithMany(p => p.Anexos)
                .HasForeignKey(p => p.Id_Mensagem_Grupo);
        }
    }

}
