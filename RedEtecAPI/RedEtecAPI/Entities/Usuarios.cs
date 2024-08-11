using RedEtecAPI.Entities.Enums;

namespace RedEtecAPI.Entities
{
    public class Usuarios
    {
        public int Id_Usuarios { get; set; }
        public int Id_Matricula { get; set; }
        public int Id_Perfil { get; set; }
        public string Nome_Usuario { get; set; }
        public string CPF_Usuario { get; set; } //Mudar banco
        public DateTime Data_Nascimento_Usuario { get; set; }
        public string Cidade_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Senha_Usuario { get; set; }
        public Sexo_Usuario Sexo_Usuario { get; set; }
        public int Nivel_Acesso { get; set; }
        public DateTime Data_Ultimo_Login { get; set; }
        public Matricula Matricula { get; set; }
        public Perfil Perfil { get; set; }
    }
}
