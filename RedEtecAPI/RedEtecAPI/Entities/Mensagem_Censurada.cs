namespace RedEtecAPI.Entities
{
    public class Mensagem_Censurada
    {
        public int Id_Mensagem_Censurada { get; set; }
        public int? Id_Usuario_Emissor { get; set; }
        public int? Id_Usuario_Receptor { get; set; }
        public int Id_Grupo { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data_Enviada { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
