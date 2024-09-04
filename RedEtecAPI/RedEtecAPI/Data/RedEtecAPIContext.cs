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
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Conexao> Conexoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Integrante_Grupo> Integrante_Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Materia_Curso> Materia_Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Mensagem_Privada> Mensagem_Privadas { get; set; }
        public DbSet<Notificacao> Notificacaos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Professor_Curso> Professor_Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnexoMapping());
            modelBuilder.ApplyConfiguration(new ComentarioMapping());
            modelBuilder.ApplyConfiguration(new ConexaoMapping());
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new CurtidaMapping());
            modelBuilder.ApplyConfiguration(new GrupoMapping());
            modelBuilder.ApplyConfiguration(new Integrante_GrupoMapping());
            modelBuilder.ApplyConfiguration(new MateriaMapping());
            modelBuilder.ApplyConfiguration(new Materia_CursoMapping());
            modelBuilder.ApplyConfiguration(new MatriculaMapping());
            modelBuilder.ApplyConfiguration(new Mensagem_PrivadaMapping());
            modelBuilder.ApplyConfiguration(new NotificacaoMapping());
            modelBuilder.ApplyConfiguration(new PerfilMapping());
            modelBuilder.ApplyConfiguration(new PostagemMapping());
            modelBuilder.ApplyConfiguration(new ProfessorMapping());
            modelBuilder.ApplyConfiguration(new Professor_CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }


}
