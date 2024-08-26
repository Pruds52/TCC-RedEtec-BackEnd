namespace RedEtecAPI.Entities
{
    public class Curtida
    {
        public int Id_Curtida { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Postagem { get; set; }
        public DateTime? Data_Curtida { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Postagem Postagem { get; set; }
    }
}
