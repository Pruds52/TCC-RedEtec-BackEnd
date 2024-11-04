using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class CursoService : GenericService<Curso>
    {
        private readonly RedEtecAPIContext _context;

        public CursoService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}
