using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class PostagemService : GenericService<Postagem>
    {
        private readonly RedEtecAPIContext _context;

        public PostagemService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Postagem>> GetPostagensByUsuarioAsync(int usuarioId)
        {
            return await _context.Postagens.Where(p => p.Id_Usuario == usuarioId).ToListAsync();
        }
    }
}
