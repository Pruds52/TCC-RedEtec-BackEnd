using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class Mensagem_PrivadaService : GenericService<Mensagem_Privada>
    {
        private readonly RedEtecAPIContext _context;

        public Mensagem_PrivadaService(RedEtecAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Mensagem_Privada>> GetConversa(int usuarioLogadoId, int contatoId)
        {
            var mensagens = await _context.Mensagem_Privadas.Where(p => p.Id_Usuario_Emissor == usuarioLogadoId && p.Id_Usuario_Receptor == contatoId).ToListAsync();

            return mensagens;
        }
    }
}
