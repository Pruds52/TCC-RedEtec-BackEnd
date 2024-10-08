using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;

namespace RedEtecAPI.Controllers
{
    public class ChatController : Controller
    {
        private readonly Mensagem_PrivadaService _mensagemPrivadaService;
        private readonly TokenJWTController _tokenJwtController;

        public ChatController(Mensagem_PrivadaService mensagemPrivadaService, TokenJWTController tokenJWTController)
        {
            _mensagemPrivadaService = mensagemPrivadaService;
            _tokenJwtController = tokenJWTController;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetConversa(int id)
        {
            var usuarioLogado = await _tokenJwtController.RecuperaSessao();

            var conversa = await _mensagemPrivadaService.GetConversa(usuarioLogado.Id_Usuario, id);

            conversa = conversa.OrderBy(p => p.Data_Mensagem).ToList();

            return Ok(conversa);
        }
    }
}
