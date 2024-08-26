using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Integrante_GrupoMapping : IEntityTypeConfiguration<Integrante_Grupo>
    {
        public void Configure(EntityTypeBuilder<Integrante_Grupo> builder)
        {
            builder.HasKey(p => p.Id_Integrante_Grupo);

            builder.Property(p => p.Id_Integrante_Grupo).IsRequired();
            builder.Property(p => p.Id_Grupo).IsRequired();
            builder.Property(p => p.Id_Usuario);
            builder.Property(p => p.Id_Professor);
            builder.Property(p => p.Data_Entrada).IsRequired();

            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Integrante_Grupos)
                .HasForeignKey(p => p.Id_Grupo);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Integrante_Grupos)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasOne(p => p.Professor)
                .WithMany(p => p.Integrante_Grupos)
                .HasForeignKey(p => p.Id_Professor);
        }
    }
}