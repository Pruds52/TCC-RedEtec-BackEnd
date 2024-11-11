using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class Mensagem_GrupoService : GenericService<Mensagem_Grupo>
    {
        private readonly RedEtecAPIContext _context;

        public Mensagem_GrupoService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Mensagem_Grupo>> GetMensagensByGrupoId(int grupoId)
        {
            return await _context.Mensagem_Grupos.Where(p => p.Id_Grupo == grupoId).ToListAsync();
        }

    }
}
