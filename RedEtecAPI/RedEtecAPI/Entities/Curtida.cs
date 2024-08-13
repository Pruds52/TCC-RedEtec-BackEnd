namespace RedEtecAPI.Entities
{
    public class Curtida
    {
        public int Id_Curtida { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Postagem { get; set; }
        public DateTime Data_Curtida { get; set; }
        public Usuario Usuario { get; set; }
        public Postagem Postagem { get; set; }
    }
}
