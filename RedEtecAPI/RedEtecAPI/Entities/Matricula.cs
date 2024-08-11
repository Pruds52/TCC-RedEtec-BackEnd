namespace RedEtecAPI.Entities
{
    public class Matricula
    {
        public int Id_Matricula { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Cursos { get; set; }
        public Usuarios Usuarios { get; set; }
        public Cursos Cursos { get; set; }
    }
}
