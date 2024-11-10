namespace RedEtecAPI.Entities
{
    public class Anexo
    {
        public int Id_Anexo { get; set; }
        public int? Id_Postagem { get; set; }
        public int? Id_Mensagem_Grupo { get; set; }
        public string Nome_Arquivo { get; set; }
        public string Tipo_Anexo { get; set; }
        public string Caminho_Anexo { get; set; }
        public DateTime DataAnexo { get; set; }
        public int Deletado_Anexo { get; set; }
        public virtual Postagem Postagem { get; set; }
        public virtual Mensagem_Grupo Mensagem_Grupo { get; set; }
    }
}
