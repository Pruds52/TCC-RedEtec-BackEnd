using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class CurtidaMapping : IEntityTypeConfiguration<Curtida>
    {
        public void Configure(EntityTypeBuilder<Curtida> builder)
        {
            builder.ToTable("Curtida");
            builder.HasKey(p => p.Id_Curtida);

            builder.Property(p => p.Id_Curtida).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Id_Postagem).IsRequired();
            builder.Property(p => p.Data_Curtida);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Curtidas)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasOne(p => p.Postagem)
                .WithMany(p => p.Curtidas)
                .HasForeignKey(p => p.Id_Postagem);
        }
    }

}
