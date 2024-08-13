namespace RedEtecAPI.Entities
{
    public class Professor
    {
        public int Id_Professores { get; set; }
        public int Nome_Professor { get; set; }
        public ICollection<Professor_Curso> Professor_Cursos { get; set; }
        public ICollection<Materia> Materias { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
        public ICollection<Integrante_Grupo> Integrante_Grupos { get; set; }

        public Professor()
        {
            Professor_Cursos = new List<Professor_Curso>();
            Materias = new List<Materia>();
            Grupos = new List<Grupo>();
            Integrante_Grupos = new List<Integrante_Grupo>();
        }
    }
}
