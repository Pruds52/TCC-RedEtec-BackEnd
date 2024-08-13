using System.Reflection.Metadata.Ecma335;

namespace RedEtecAPI.Entities
{
    public class Materia_Curso
    {
        public int Id_Materia_Curso { get; set; }
        public int Id_Materia { get; set; }
        public int Id_Curso { get; set; }
        public Materia Materia { get; set; }
        public Curso Curso { get; set; }
    }
}
