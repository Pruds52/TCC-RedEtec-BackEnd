using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matricula");
            builder.HasKey(p => p.Id_Matricula);

            builder.Property(p => p.Id_Matricula).IsRequired();
            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Id_Curso).IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasOne(p => p.Curso)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.Id_Curso);
        }
    }
}
