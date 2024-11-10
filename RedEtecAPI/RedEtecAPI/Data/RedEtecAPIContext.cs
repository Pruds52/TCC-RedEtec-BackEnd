using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using RedEtecAPI.Entities;
using RedEtecAPI.Mapping;

namespace RedEtecAPI.Data
{
    public class RedEtecAPIContext : DbContext
    {
        public RedEtecAPIContext(DbContextOptions<RedEtecAPIContext> options)
            : base(options) { }

        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Integrante_Grupo> Integrante_Grupos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Mensagem_Privada> Mensagem_Privadas { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem_Grupo> Mensagem_Grupos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnexoMapping());
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new GrupoMapping());
            modelBuilder.ApplyConfiguration(new Integrante_GrupoMapping());
            modelBuilder.ApplyConfiguration(new MatriculaMapping());
            modelBuilder.ApplyConfiguration(new Mensagem_PrivadaMapping());
            modelBuilder.ApplyConfiguration(new PerfilMapping());
            modelBuilder.ApplyConfiguration(new PostagemMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new Mensagem_GrupoMapping());
        }
    }


}
