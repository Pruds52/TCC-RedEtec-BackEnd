using System.Text.Json.Serialization;

namespace RedEtecAPI.Entities
{
    public class Matricula
    {
        public int Id_Matricula { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Curso { get; set; }
        public int Deletado_Matricula { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public virtual Curso Curso { get; set; }
    }
}
