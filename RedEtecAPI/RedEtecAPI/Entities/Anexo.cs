namespace RedEtecAPI.Entities
{
    public class Anexo
    {
        public int Id_Anexo { get; set; }
        public int Id_Postagem { get; set; }
        public int Id_Mensagens_Privada { get; set; }
        public string Nome_Arquivo { get; set; }
        public string Tipo_Anexo { get; set; }
        public string Caminho_Anexo { get; set; }
        public DateTime DataAnexo { get; set; }
        public Postagem Postagem { get; set; }
        public Mensagem_Privada Mensagem_Privada { get; set; }
    }
}
