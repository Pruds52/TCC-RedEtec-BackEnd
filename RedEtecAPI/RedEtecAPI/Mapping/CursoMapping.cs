using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(p => p.Id_Curso);

            builder.Property(p => p.Id_Curso).IsRequired();
            builder.Property(p => p.Nome_Curso).IsRequired().HasMaxLength(45);
            builder.Property(p => p.Horario_Curso).IsRequired().HasMaxLength(45);

            builder.HasMany(p => p.Materia_Cursos)
                .WithOne(p => p.Curso)
                .HasForeignKey(p => p.Id_Curso);

            builder.HasMany(p => p.Professor_Cursos)
                .WithOne(p => p.Curso)
                .HasForeignKey(p => p.Id_Curso);

            builder.HasMany(p => p.Matriculas)
                .WithOne(p => p.Curso)
                .HasForeignKey(p => p.Id_Curso);
        }
    }
}
