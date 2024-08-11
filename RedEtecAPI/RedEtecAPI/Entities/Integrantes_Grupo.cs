namespace RedEtecAPI.Entities
{
    public class Integrantes_Grupo
    {
        public int Id_Grupos_Usuarios { get; set; }
        public int Id_Grupos { get; set; }
        public int Id_Usuarios { get; set; }
        public int Id_Professores { get; set; }
        public DateTime Data_Entrada { get; set; }
        public Grupos Grupos { get; set; }
        public Usuarios Usuarios { get; set; }
        public Professores Professores { get; set; }
    }
}
