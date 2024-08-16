using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class UsuarioService
    {
        private readonly RedEtecAPIContext _context;

        public UsuarioService(RedEtecAPIContext context) 
        { 
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task InsertAsync(Usuario usuario)
        {
            _context.Add(usuario);

            await _context.SaveChangesAsync();
        }
    }
}
