using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using System.Security.Claims;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly Mensagem_PrivadaService _mensagemPrivadaService;
        private readonly TokenJWTController _tokenJwtController;
        private readonly UsuarioService _usuarioService;

        public ChatController(Mensagem_PrivadaService mensagemPrivadaService, TokenJWTController tokenJWTController, UsuarioService usuarioService)
        {
            _mensagemPrivadaService = mensagemPrivadaService;
            _tokenJwtController = tokenJWTController;
            _usuarioService = usuarioService;   
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetConversa(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

            var conversa = await _mensagemPrivadaService.GetConversa(usuario.Id_Usuario, id);

            conversa = conversa.OrderBy(p => p.Data_Mensagem).ToList();

            return Ok(conversa);
        }

        [Authorize]
        [HttpPost("enviarmensagem")]
        public async Task<ActionResult> EnviarMensagem([FromBody] Chat chat)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

            var mensagemPrivada = new Mensagem_Privada
            {
                Id_Usuario_Emissor = usuario.Id_Usuario,
                Id_Usuario_Receptor = chat.receptorId,
                Mensagem = chat.mensagem,
                Data_Mensagem = DateTime.Now
            };

            await _mensagemPrivadaService.CreateAsync(mensagemPrivada);

            return Ok();
        }
    }
}
