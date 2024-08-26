namespace RedEtecAPI.Entities
{
    public class Mensagem_Privada
    {
        public int Id_Mensagem_Privada { get; set; }
        public int Id_Usuario_Emissor { get; set; }
        public int Id_Usuario_Receptor { get; set; }
        public string Mensagem { get; set; }
        public string Localizacao_Midia { get; set; }
        public DateTime Data_Mensagem { get; set; }
        public virtual ICollection<Anexo> Anexos { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Mensagem_Privada()
        {
            Anexos = new List<Anexo>();
        }
    }
}
