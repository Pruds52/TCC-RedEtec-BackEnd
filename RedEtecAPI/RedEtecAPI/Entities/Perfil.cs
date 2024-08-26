namespace RedEtecAPI.Entities
{
    public class Perfil
    {
        public int Id_Perfil { get; set; }
        public int Id_Usuario { get; set; }
        public string Foto_Perfil { get; set; }
        public string Biografia_Perfil { get; set; }
        public DateTime Data_Atualização_Perfil { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
