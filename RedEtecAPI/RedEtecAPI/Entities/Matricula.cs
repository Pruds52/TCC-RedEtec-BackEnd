namespace RedEtecAPI.Entities
{
    public class Matricula
    {
        public int Id_Matricula { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Curso { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
