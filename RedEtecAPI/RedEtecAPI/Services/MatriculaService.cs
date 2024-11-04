using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class MatriculaService : GenericService<Matricula>
    {
        private readonly RedEtecAPIContext _context;

        public MatriculaService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Matricula>> GetMatriculasByUsuarioId(int usuarioId)
        {
            return await _context.Matriculas.Include(t => t.Curso).Where(p => p.Id_Usuario == usuarioId).ToListAsync();
        }
    }
}
