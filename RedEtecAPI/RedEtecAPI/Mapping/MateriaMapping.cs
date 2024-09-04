using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class MateriaMapping : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materia");
            builder.HasKey(p => p.Id_Materia);

            builder.Property(p => p.Id_Materia).IsRequired();
            builder.Property(p => p.Id_Professor).IsRequired();
            builder.Property(p => p.Nome_Materia).IsRequired().HasMaxLength(45);
            builder.Property(p => p.Modulo_Materia).IsRequired();

            builder.HasOne(p => p.Professor)
                .WithMany(p => p.Materias)
                .HasForeignKey(p => p.Id_Professor);

            builder.HasMany(p => p.Materia_Cursos)
                .WithOne(p => p.Materia)
                .HasForeignKey(p => p.Id_Materia);
        }
    }
}
