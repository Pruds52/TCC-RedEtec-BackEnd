using System.Text.Json.Serialization;

namespace RedEtecAPI.Entities
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
        public string CPF_Usuario { get; set; }
        public DateTime Data_Nascimento_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Senha_Usuario { get; set; }
        public int Nivel_Acesso { get; set; }
        public int Deletado_Usuario { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Postagem> Postagens { get; set; }
        [JsonIgnore]
        public virtual ICollection<Integrante_Grupo> Integrante_Grupos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mensagem_Privada> Mensagem_Privadas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mensagem_Grupo> Mensagem_Grupos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Perfil> Perfis { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grupo> Grupos { get; set; }

        public Usuario()
        {
            Matriculas = new List<Matricula>();
            Postagens = new List<Postagem>();
            Integrante_Grupos = new List<Integrante_Grupo>();
            Mensagem_Privadas = new List<Mensagem_Privada>();
            Mensagem_Grupos = new List<Mensagem_Grupo>();
            Perfis = new List<Perfil>();
            Grupos = new List<Grupo>();
        }
    }
}
