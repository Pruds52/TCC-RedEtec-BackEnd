using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class ProfessorService : GenericService<Professor>
    {
        private readonly RedEtecAPIContext _context;

        public ProfessorService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}
