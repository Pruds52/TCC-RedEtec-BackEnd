using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(p => p.Id_Perfil);

            builder.Property(p => p.Id_Perfil).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Foto_Perfil).HasMaxLength(256);
            builder.Property(p => p.Biografia_Perfil);
            builder.Property(p => p.Data_Atualização_Perfil).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Perfis)
                .HasForeignKey(p => p.Id_Usuario);
        }
    }
}
