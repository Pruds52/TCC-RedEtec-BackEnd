namespace RedEtecAPI.Entities
{
    public class Curso
    {
        public int Id_Curso { get; set; }
        public string Nome_Curso { get; set; }
        public string Horario_Curso { get; set; }
        public int Deletado_Curso { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }

        public Curso()
        {
            Matriculas = new List<Matricula>();
        }
    }
}
