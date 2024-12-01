using RedEtecAPI.Entities;

namespace RedEtecAPI.VM
{
    public class ChatGrupo
    {
        public int Id_Grupo { get; set; }
        public int Id_Usuario_Emissor { get; set; }
        public string Mensagem { get; set; }
        public string Localizacao_Arquivo { get; set; }
        public string TipoAnexo { get; set; }
        public DateTime Data_Enviada { get; set; }
        public int Deletado_Mensagem_Grupo { get; set; }
    }
}
