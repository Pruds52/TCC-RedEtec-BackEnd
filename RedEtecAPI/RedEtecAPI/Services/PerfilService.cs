using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class PerfilService : GenericService<Perfil>
    {
        private readonly RedEtecAPIContext _context;

        public PerfilService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Perfil> GetPerfilByUsuarioId(int usuarioId)
        {
            var perfil = await _context.Perfis.Where(p => p.Id_Usuario == usuarioId).LastOrDefaultAsync();

            return perfil;
        }
    }
}
