﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id_Usuario);

            builder.Property(p => p.Id_Usuario).IsRequired();
            builder.Property(p => p.Nome_Usuario).IsRequired().HasMaxLength(45);
            builder.Property(p => p.CPF_Usuario).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Data_Nascimento_Usuario).IsRequired();
            builder.Property(p => p.Email_Usuario).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Senha_Usuario).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Nivel_Acesso).IsRequired();
            builder.Property(p => p.Deletado_Usuario).IsRequired();

            builder.HasMany(p => p.Matriculas)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasMany(p => p.Postagens)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasMany(p => p.Integrante_Grupos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasMany(p => p.Mensagem_Privadas)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario_Emissor);

            builder.HasMany(p => p.Mensagem_Privadas)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario_Receptor);

            builder.HasMany(p => p.Mensagem_Grupos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario_Emissor);

            builder.HasMany(p => p.Perfis)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Usuario);

            builder.HasMany(p => p.Grupos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_Criador_Usuario);
        }
    }
}
