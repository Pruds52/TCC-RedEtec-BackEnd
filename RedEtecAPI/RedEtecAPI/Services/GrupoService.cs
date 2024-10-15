using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class GrupoService : GenericService<Grupo>
    {
        private readonly RedEtecAPIContext _context;

        public GrupoService(RedEtecAPIContext context) : base(context) 
        {
            _context = context;
        }

    }
}
