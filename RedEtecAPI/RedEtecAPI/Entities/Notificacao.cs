using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace RedEtecAPI.Entities
{
    public class Notificacao
    {
        public int Id_Notificacao { get; set; }
        public int Id_Usuario { get; set; }
        public string Tipo_Notificacao { get; set; }
        public string Mensagem_Notificacao { get; set; }
        public DateTime Data_Notificacao { get; set; }
        public bool Lida_Notificacao { get; set; } //Mudar banco para bool
        public Usuarios Usuarios { get; set; }
    }
}
