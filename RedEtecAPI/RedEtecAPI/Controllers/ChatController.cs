using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
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

            var chatCompleto = new List<Chat>();


            foreach (var item in conversa)
            {
                var mensagem = new Chat();

                mensagem.MensagemId = item.Id_Mensagem_Privada;
                mensagem.EmissorId = item.Id_Usuario_Emissor;
                mensagem.ReceptorId = item.Id_Usuario_Receptor;
                mensagem.Mensagem = item.Mensagem;
                mensagem.LocalizacaoMidia = item.Localizacao_Midia;

                chatCompleto.Add(mensagem);
            }

            return Ok(chatCompleto);
        }

        [Authorize]
        [HttpPost("enviarmensagem")]
        public async Task<ActionResult> EnviarMensagem([FromBody] Chat chat, [FromForm] IFormFile file)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (file != null && file.Length != 0)
            {
                var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
                var database = client.GetDatabase("Testes-TCC");
                var gridFS = new GridFSBucket(database);

                using (var stream = file.OpenReadStream())
                {
                    var fileId = await gridFS.UploadFromStreamAsync(file.FileName, stream);
                    chat.LocalizacaoMidia = fileId.ToString();
                }
            }

            var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

            var mensagemPrivada = new Mensagem_Privada
            {
                Id_Usuario_Emissor = usuario.Id_Usuario,
                Id_Usuario_Receptor = chat.ReceptorId,
                Mensagem = chat.Mensagem,
                Localizacao_Midia = chat.LocalizacaoMidia,
                Data_Mensagem = DateTime.Now
            };

            await _mensagemPrivadaService.CreateAsync(mensagemPrivada);

            return Ok("Mensagem Enviada");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMensagem(int id)
        {
            var mensagem = await _mensagemPrivadaService.GetByIdAsync(id);

            await _mensagemPrivadaService.DeleteAsync(mensagem);

            return Ok("Mensagem excluída.");
        }
    }
}
