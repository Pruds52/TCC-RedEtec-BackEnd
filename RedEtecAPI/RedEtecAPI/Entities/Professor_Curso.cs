namespace RedEtecAPI.Entities
{
    public class Professor_Curso
    {
        public int Id_Professor_Curso { get; set; }
        public int Id_Cursos { get; set; }
        public int Id_Professor { get; set; }
        public Curso Curso { get; set; }
        public Professor Professor { get; set; }
    }
}
