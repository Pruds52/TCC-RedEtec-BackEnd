namespace RedEtecAPI.VM
{
    public class UsuarioViewModels
    {
        public int Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
        public string CPF_Usuario { get; set; }
        public DateTime Data_Nascimento_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Senha_Usuario { get; set; }
        public int Nivel_Acesso { get; set; }
        public int Deletado_Usuario { get; set; }
        public int Id_Curso { get; set; }
    }
}
