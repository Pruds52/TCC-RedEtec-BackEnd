using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class Mensagem_CensuradaService : GenericService<Mensagem_Censurada>
    {
        private readonly RedEtecAPIContext _context;

        public Mensagem_CensuradaService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}
