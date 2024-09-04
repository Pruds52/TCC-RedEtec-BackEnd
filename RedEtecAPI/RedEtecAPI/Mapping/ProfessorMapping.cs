using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(p => p.Id_Professor);

            builder.Property(p => p.Id_Professor).IsRequired();
            builder.Property(p => p.Nome_Professor).IsRequired().HasMaxLength(45);
            builder.Property(p => p.Senha_Professor).IsRequired().HasMaxLength(30);

            builder.HasMany(p => p.Professor_Cursos)
               .WithOne(p => p.Professor)
               .HasForeignKey(p => p.Id_Professor);

            builder.HasMany(p => p.Materias)
               .WithOne(p => p.Professor)
               .HasForeignKey(p => p.Id_Professor);

            builder.HasMany(p => p.Grupos)
               .WithOne(p => p.Professor)
               .HasForeignKey(p => p.Id_Criador_Professor);

            builder.HasMany(p => p.Integrante_Grupos)
               .WithOne(p => p.Professor)
               .HasForeignKey(p => p.Id_Professor);
        }
    }
}
