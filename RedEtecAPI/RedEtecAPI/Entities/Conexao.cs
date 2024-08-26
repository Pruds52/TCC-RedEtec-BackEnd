namespace RedEtecAPI.Entities
{
    public class Conexao
    {
        public int Id_Conexao { get; set; }
        public int Solicitacao_Enviada { get; set; }
        public int Solicitacao_Solicitada { get; set; }
        public DateTime Data_Conexao { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
