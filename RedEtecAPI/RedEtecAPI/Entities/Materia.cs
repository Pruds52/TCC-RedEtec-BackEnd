namespace RedEtecAPI.Entities
{
    public class Materia
    {
        public int Id_Materia { get; set; }
        public int Id_Professor { get; set; }
        public string Nome_Materia { get; set; }
        public int Modulo_Materia { get; set; }
        public string Id_Professorlala { get; set; } // Que porra é essa???
        public Professores Professores { get; set; }
    }
}
