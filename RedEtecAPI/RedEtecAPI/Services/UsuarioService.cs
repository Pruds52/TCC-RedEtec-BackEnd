using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return 
                 await _context.Usuario.FindAsync(id);
        }

        public async Task CreateAsync(Usuario usuario)
        {
            _context.Add(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _context.Remove(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var usuarioExiste = await _context.Usuario.AnyAsync(p => p.Nome_Usuario == username && p.Senha_Usuario == password);

            return usuarioExiste;
        }
    }
}
