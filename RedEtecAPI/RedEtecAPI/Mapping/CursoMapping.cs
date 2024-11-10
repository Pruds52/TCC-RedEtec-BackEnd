using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");
            builder.HasKey(p => p.Id_Curso);

            builder.Property(p => p.Id_Curso).IsRequired();
            builder.Property(p => p.Nome_Curso).IsRequired().HasMaxLength(45);
            builder.Property(p => p.Deletado_Curso).IsRequired();

            builder.HasMany(p => p.Matriculas)
                .WithOne(p => p.Curso)
                .HasForeignKey(p => p.Id_Curso);
        }
    }
}
