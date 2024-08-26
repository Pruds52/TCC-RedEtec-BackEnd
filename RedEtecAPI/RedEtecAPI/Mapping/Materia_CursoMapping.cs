using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Materia_CursoMapping : IEntityTypeConfiguration<Materia_Curso>
    {
        public void Configure(EntityTypeBuilder<Materia_Curso> builder)
        {
            builder.HasKey(p => p.Id_Materia_Curso);

            builder.Property(p => p.Id_Materia_Curso).IsRequired();
            builder.Property(p => p.Id_Materia).IsRequired();
            builder.Property(p => p.Id_Curso).IsRequired();

            builder.HasOne(p => p.Materia)
                .WithMany(p => p.Materia_Cursos)
                .HasForeignKey(p => p.Id_Materia);

            builder.HasOne(p => p.Curso)
                .WithMany(p => p.Materia_Cursos)
                .HasForeignKey(p => p.Id_Curso);
        }
    }
}
