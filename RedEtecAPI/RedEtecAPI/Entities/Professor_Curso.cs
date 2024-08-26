namespace RedEtecAPI.Entities
{
    public class Professor_Curso
    {
        public int Id_Professor_Curso { get; set; }
        public int? Id_Curso { get; set; }
        public int? Id_Professor { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
