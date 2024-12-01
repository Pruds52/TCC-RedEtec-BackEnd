namespace RedEtecAPI.VM
{
    public class PostagemViewModels
    {
        public int Id_Postagem { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Curso { get; set; }
        public string Legenda_Postagem { get; set; }
        public string imageUrl { get; set; }
        public string Nome_Usuario { get; set; }
        public int Nivel_Acesso { get; set; }
        public DateTime Data_Postagem { get; set; }
    }
}
