using RedEtecAPI.Entities.Enums;

namespace RedEtecAPI.Entities
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
        public string CPF_Usuario { get; set; }
        public DateTime Data_Nascimento_Usuario { get; set; }
        public string Cidade_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Senha_Usuario { get; set; }
        public char Sexo_Usuario { get; set; }
        public int Nivel_Acesso { get; set; }
        //public ICollection<Matricula> Matriculas { get; set; }
        //public ICollection<Comentario> Comentarios { get; set; }
        //public ICollection<Curtida> Curtidas { get; set; }
        //public ICollection<Postagem> Postagens { get; set; }
        //public ICollection<Notificacao> Notificacoes { get; set; }
        //public ICollection<Integrante_Grupo> Integrante_Grupos { get; set; }
        //public ICollection<Conexao> Conexoes { get; set; }
        //public ICollection<Mensagem_Privada> Mensagem_Privadas { get; set; }
        //public ICollection<Perfil> Perfis { get; set; }

        //public Usuario()
        //{
        //    Matriculas = new List<Matricula>();
        //    Comentarios = new List<Comentario>();
        //    Curtidas = new List<Curtida>();
        //    Postagens = new List<Postagem>();
        //    Notificacoes = new List<Notificacao>();
        //    Integrante_Grupos = new List<Integrante_Grupo>();
        //    Conexoes = new List<Conexao>();
        //    Mensagem_Privadas = new List<Mensagem_Privada>();
        //    Perfis = new List<Perfil>();
        //}
    }
}
