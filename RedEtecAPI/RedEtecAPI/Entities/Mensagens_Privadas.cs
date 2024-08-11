namespace RedEtecAPI.Entities
{
    public class Mensagens_Privadas
    {
        public int Id_Mensagem_Privadas { get; set; }
        public int Id_Usuario_Emissor { get; set; }
        public int Id_Usuario_Receptor { get; set; }
        public string Mensagem { get; set; }
        public string Localizacao_Midia { get; set; }
        public DateTime Data_Mensagem { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
