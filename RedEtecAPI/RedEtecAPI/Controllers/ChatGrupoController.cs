using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using RedEtecAPI.VM;
using System.Security.Claims;
using System;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatGrupoController : Controller
    {
        private readonly Mensagem_GrupoService _mensagemGrupoService;
        private readonly GrupoService _grupoService;

        public ChatGrupoController(Mensagem_GrupoService mensagem_GrupoService, GrupoService grupoService)
        {
            _mensagemGrupoService = mensagem_GrupoService;
            _grupoService = grupoService;
        }

        [HttpGet("{grupoId}")]
        public async Task<ActionResult> GetMensagensGrupo(int grupoId)
        {
            var mensagens = await _mensagemGrupoService.GetMensagensByGrupoId(grupoId);

            return Ok(mensagens);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EnviarMensagemGrupo(ChatGrupo chatGrupo, IFormFile file)
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
                    chatGrupo.Localizacao_Arquivo = fileId.ToString();
                }
            }

            var mensagemGrupo = new Mensagem_Grupo
            {
                Id_Grupo = chatGrupo.Id_Grupo,
                Id_Usuario_Emissor = chatGrupo.Id_Usuario_Emissor,
                Mensagem = chatGrupo.Mensagem,
                Localizacao_Arquivo = chatGrupo.Localizacao_Arquivo,
            };

            await _mensagemGrupoService.CreateAsync(mensagemGrupo);

            return Ok("Mensagem Enviada");
        }
    }
}
