namespace RedEtecAPI.Entities
{
    public class Grupo
    {
        public int Id_Grupo { get; set; }
        public int Id_Criador_Professor { get; set; }
        public string Nome_Grupo { get; set; }
        public string Descricao_Grupo { get; set; }
        public string Localizacao_Foto { get; set; }
        public DateTime Data_Criacao { get; set; }
        public virtual ICollection<Integrante_Grupo> Integrante_Grupos { get; set; }
        public virtual Professor Professor { get; set; }

        public Grupo()
        {
            Integrante_Grupos = new List<Integrante_Grupo>();
        }
    }
}
