using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using RedEtecAPI.VM;
using System.Security.Claims;
using System;
using MongoDB.Bson;
using Amazon.Runtime;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatGrupoController : Controller
    {
        private readonly Mensagem_GrupoService _mensagemGrupoService;
        private readonly GrupoService _grupoService;
        private readonly AnexoService _anexoService;
        private readonly CensuraController _censuraController;
        private readonly Mensagem_CensuradaService _mensagemCensuradaService;

        public ChatGrupoController(Mensagem_GrupoService mensagemGrupoService, GrupoService grupoService, AnexoService anexoService, CensuraController censuraController, Mensagem_CensuradaService mensagemCensuradaService)
        {
            _mensagemGrupoService = mensagemGrupoService;
            _grupoService = grupoService;
            _anexoService = anexoService;
            _censuraController = censuraController;
            _mensagemCensuradaService = mensagemCensuradaService;
        }

        [HttpGet("{grupoId}")]
        public async Task<ActionResult> GetMensagensGrupo(int grupoId)
        {
            var mensagens = await _mensagemGrupoService.GetMensagensByGrupoId(grupoId);

            var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
            var database = client.GetDatabase("Testes-TCC");
            var gridFS = new GridFSBucket(database);

            var mensagensComAnexos = mensagens.Select(async mensagem =>
            {
                if (!string.IsNullOrEmpty(mensagem.Localizacao_Arquivo))
                {
                    var fileId = new ObjectId(mensagem.Localizacao_Arquivo);
                    var downloadStream = await gridFS.OpenDownloadStreamAsync(fileId);
                    var fileUrl = mensagem.Localizacao_Arquivo;

                    return new
                    {
                        mensagem.Id_Mensagem_Grupo,
                        mensagem.Id_Grupo,
                        mensagem.Id_Usuario_Emissor,
                        mensagem.Mensagem,
                        mensagem.Data_Enviada,
                        AnexoUrl = fileUrl,
                        TipoAnexo = downloadStream.FileInfo.Metadata.Contains("contentType") ? downloadStream.FileInfo.Metadata["contentType"].AsString : null
                    };
                }

                return new
                {
                    mensagem.Id_Mensagem_Grupo,
                    mensagem.Id_Grupo,
                    mensagem.Id_Usuario_Emissor,
                    mensagem.Mensagem,
                    mensagem.Data_Enviada,
                    AnexoUrl = (string)null,
                    TipoAnexo = (string)null
                };
            });

            var resultados = await Task.WhenAll(mensagensComAnexos);

            return Ok(resultados);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EnviarMensagemGrupo([FromForm] ChatGrupo chatGrupo, [FromForm] IFormFile file)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var censura = _censuraController.CensurarMensagem(chatGrupo.Mensagem);

            if (censura)
            {
                var mensagemCensurada = new Mensagem_Censurada
                {
                    Id_Usuario_Emissor = Convert.ToInt32(userId),
                    Id_Grupo = chatGrupo.Id_Grupo,
                    Mensagem = chatGrupo.Mensagem,
                    Data_Enviada = DateTime.Now
                };

                await _mensagemCensuradaService.CreateAsync(mensagemCensurada);

                return Ok("Mensagem censurada");
            }

            if (file != null && file.Length > 0)
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
                Id_Usuario_Emissor = Convert.ToInt32(userId),
                Mensagem = chatGrupo.Mensagem,
                Localizacao_Arquivo = chatGrupo.Localizacao_Arquivo,
                Data_Enviada = DateTime.Now
            };

            await _mensagemGrupoService.CreateAsync(mensagemGrupo);

            if (file != null && file.Length > 0 && mensagemGrupo.Id_Mensagem_Grupo != 0)
            {
                var anexo = new Anexo()
                {
                    Id_Mensagem_Grupo = mensagemGrupo.Id_Mensagem_Grupo,
                    Nome_Arquivo = file.FileName,
                    Tipo_Anexo = file.ContentType,
                    Caminho_Anexo = chatGrupo.Localizacao_Arquivo
                };

                await _anexoService.CreateAsync(anexo);
            }

            return Ok("Mensagem e arquivo enviados com sucesso.");
        }

        [HttpPost("enviarimagem")]

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMensagem(int id)
        {
            var mensagem = await _mensagemGrupoService.GetByIdAsync(id);

            await _mensagemGrupoService.DeleteAsync(mensagem);

            return Ok("Mensagem excluída.");
        }

    }
}
