namespace RedEtecAPI.Entities
{
    public class Comentarios
    {
        public int Id_Comentarios { get; set; }
        public int Id_Usuarios { get; set; }
        public int Id_Postagem { get; set; }
        public string Comentario { get; set; }
        public DateTime Data_Comentario { get; set; }
        public Usuarios Usuarios { get; set; }
        public Postagem Postagem { get; set; }
    }
}
