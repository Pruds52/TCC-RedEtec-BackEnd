namespace RedEtecAPI.Entities
{
    public class Grupos
    {
        public int Id_Grupos { get; set; }
        public int Id_Criado_Professor { get; set; }
        public string Nome_Grupos { get; set; }
        public string Descricao_Grupos { get; set; }
        public string Localizacao_Foto { get; set; }
        public DateTime Data_Criacao { get; set; }
        public Professores Professores { get; set; }
    }
}
