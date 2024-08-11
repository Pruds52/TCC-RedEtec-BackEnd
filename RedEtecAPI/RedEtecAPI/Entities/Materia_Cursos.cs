using System.Reflection.Metadata.Ecma335;

namespace RedEtecAPI.Entities
{
    public class Materia_Cursos
    {
        public int Id_Materia_Cursos { get; set; }
        public int Id_Materia { get; set; }
        public int Id_Cursos { get; set; }
        public Materia Materia { get; set; }
        public Cursos Cursos { get; set; }
    }
}
