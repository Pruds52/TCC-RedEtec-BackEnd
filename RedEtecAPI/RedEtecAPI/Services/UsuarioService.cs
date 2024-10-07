using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Plugins;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class UsuarioService : GenericService<Usuario>
    {
        private readonly RedEtecAPIContext _context;

        public UsuarioService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> LoginAsync(string username, string password)
        {
            var usuarioExiste = await _context.Usuarios.Where(p => p.Nome_Usuario == username && p.Senha_Usuario == password).FirstAsync();

            return usuarioExiste;
        }
    }
}
