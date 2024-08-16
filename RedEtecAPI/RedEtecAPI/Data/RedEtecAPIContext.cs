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

        //public DbSet<Anexo> Anexo { get; set; }
        //public DbSet<Comentario> Comentario { get; set; }
        //public DbSet<Conexao> Conexao { get; set; }
        //public DbSet<Curso> Curso { get; set; }
        //public DbSet<Curtida> Curtida { get; set; }
        //public DbSet<Grupo> Grupo { get; set; }
        //public DbSet<Integrante_Grupo> Integrante_Grupo { get; set; }
        //public DbSet<Materia> Materia { get; set; }
        //public DbSet<Materia_Curso> Materia_Curso { get; set; }
        //public DbSet<Matricula> Matricula { get; set; }
        //public DbSet<Mensagem_Privada> Mensagem_Privada { get; set; }
        //public DbSet<Notificacao> Notificacao { get; set; }
        //public DbSet<Perfil> Perfil { get; set; }
        //public DbSet<Postagem> Postagem { get; set; }
        //public DbSet<Professor> Professor { get; set; }
        //public DbSet<Professor_Curso> Professor_Curso { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }


}
