using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace RedEtecAPI.Entities
{
    public class Postagem
    {
        public int Id_Postagem { get; set; }
        public int Id_Usuarios { get; set; }
        public string Legenda_Postagem { get; set; }
        public string Localizacao_Midia_Postagem { get; set; }
        public DateTime Data_Postagem { get; set; }
        public Usuarios Usuarioa { get; set; } 
    }
}
