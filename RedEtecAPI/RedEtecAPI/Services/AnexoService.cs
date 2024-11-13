using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class AnexoService : GenericService<Anexo>
    {
        private readonly RedEtecAPIContext _context;

        public AnexoService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}
