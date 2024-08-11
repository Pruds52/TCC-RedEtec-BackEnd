namespace RedEtecAPI.Entities
{
    public class Anexos
    {
        public int Id_Anexos { get; set; }
        public int Id_Postagem { get; set; }
        public int Id_Mensagens_Privadas { get; set; }
        public string Nome_Arquivo { get; set; }
        public string Tipo_Anexo { get; set; }
        public string Caminho_Anexo { get; set; }
        public DateTime DataAnexo { get; set; }
        public Postagem Postagem { get; set; }
        public Mensagens_Privadas Mensagens_Privadas { get; set; }
    }
}
