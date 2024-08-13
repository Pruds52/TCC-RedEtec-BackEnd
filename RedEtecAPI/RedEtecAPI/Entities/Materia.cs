namespace RedEtecAPI.Entities
{
    public class Materia
    {
        public int Id_Materia { get; set; }
        public int Id_Professor { get; set; }
        public string Nome_Materia { get; set; }
        public int Modulo_Materia { get; set; }
        public ICollection<Materia_Curso> Materia_Cursos { get; set; }
        public Professor Professor { get; set; }

        public Materia()
        {
            Materia_Cursos = new List<Materia_Curso>();
        }
    }
}
