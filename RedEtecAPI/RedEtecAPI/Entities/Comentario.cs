namespace RedEtecAPI.Entities
{
    public class Comentario
    {
        public int Id_Comentario { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Postagem { get; set; }
        public string Comentario_Postado { get; set; }
        public DateTime Data_Comentario { get; set; }
        public Usuario Usuario { get; set; }
        public Postagem Postagem { get; set; }
    }
}
