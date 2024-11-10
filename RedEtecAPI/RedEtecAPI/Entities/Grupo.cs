namespace RedEtecAPI.Entities
{
    public class Grupo
    {
        public int Id_Grupo { get; set; }
        public int Id_Criador_Usuario { get; set; }
        public string Nome_Grupo { get; set; }
        public string Descricao_Grupo { get; set; }
        public string Localizacao_Foto { get; set; }
        public DateTime Data_Criacao { get; set; }
        public int Deletado_Grupo { get; set; }
        public virtual ICollection<Integrante_Grupo> Integrante_Grupos { get; set; }
        public virtual ICollection<Mensagem_Grupo> Mensagem_Grupos { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Grupo()
        {
            Integrante_Grupos = new List<Integrante_Grupo>();
            Mensagem_Grupos = new List<Mensagem_Grupo>();
        }
    }
}
