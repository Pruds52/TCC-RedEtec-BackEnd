using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id_Usuario);

            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Id_Matricula).IsRequired();
            builder.Property(p => p.Nome_Usuario).IsRequired().HasMaxLength(45);
            builder.Property(p => p.CPF_Usuario).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Data_Nascimento_Usuario).IsRequired();
            builder.Property(p => p.Cidade_Usuario).HasMaxLength(45);
            builder.Property(p => p.Email_Usuario).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Senha_Usuario).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Sexo_Usuario).IsRequired();
            builder.Property(p => p.Nivel_Acesso).IsRequired();
        }
    }
}
