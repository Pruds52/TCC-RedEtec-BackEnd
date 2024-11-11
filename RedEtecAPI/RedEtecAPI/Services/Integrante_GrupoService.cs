using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class Integrante_GrupoService : GenericService<Integrante_Grupo>
    {
        private readonly RedEtecAPIContext _context;

        public Integrante_GrupoService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Integrante_Grupo>> GetIntegrantesByGrupoId(int grupoId)
        {
            return await _context.Integrante_Grupos.Where(p => p.Id_Grupo == grupoId).ToListAsync();
        }
    }
}
