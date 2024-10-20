namespace RedEtecAPI.Entities
{
    public class Chat
    {
        public int EmissorId { get; set; }
        public int ReceptorId { get; set; }
        public string Mensagem { get; set; }
        public string LocalizacaoMidia { get; set; }
    }
}
