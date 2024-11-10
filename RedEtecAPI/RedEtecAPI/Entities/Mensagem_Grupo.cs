using System.Reflection.Metadata.Ecma335;

namespace RedEtecAPI.Entities
{
    public class Mensagem_Grupo
    {
        public int Id_Mensagem_Grupo { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Usuario_Emissor { get; set; }
        public string Mensagem { get; set; }
        public string Localizacao_Arquivo { get; set; }
        public DateTime Data_Enviada { get; set; }
        public int Deletado_Mensagem_Grupo { get; set; }
        public ICollection<Anexo> Anexos { get; set; }
        public Grupo Grupo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
