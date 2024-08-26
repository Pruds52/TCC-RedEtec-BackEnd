using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class Professor_CursoMapping : IEntityTypeConfiguration<Professor_Curso>
    {
        public void Configure(EntityTypeBuilder<Professor_Curso> builder)
        {
            builder.HasKey(p => p.Id_Professor_Curso);

            builder.Property(p => p.Id_Professor_Curso).IsRequired();
            builder.Property(p => p.Id_Curso).IsRequired();
            builder.Property(p => p.Id_Professor_Curso).IsRequired();

            builder.HasOne(p => p.Curso)
                   .WithMany(p => p.Professor_Cursos)
                   .HasForeignKey(p => p.Id_Curso);

            builder.HasOne(p => p.Professor)
                   .WithMany(p => p.Professor_Cursos)
                   .HasForeignKey(p => p.Id_Professor);
        }
    }
}
