namespace RedEtecAPI.Entities
{
    public class Curtidas
    {
        public int Id_Curtidas { get; set; }
        public int Id_Usuarios { get; set; }
        public int Id_Postagem { get; set; }
        public DateTime Data_Curtida { get; set; }
        public Usuarios Usuarios { get; set; }
        public Postagem Postagem { get; set; }
    }
}
