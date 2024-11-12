using Microsoft.AspNetCore.Authorization;
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
    public class PerfilController : Controller
    {
        private readonly PerfilService _perfilService;
        private readonly TokenJWTController _tokenJWTController;

        public PerfilController(PerfilService perfilService, TokenJWTController tokenJWTController)
        {
            _perfilService = perfilService;
            _tokenJWTController = tokenJWTController;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Perfil>> GetPerfil()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var perfil = await _perfilService.GetPerfilByUsuarioId(Convert.ToInt32(userId));

            if (perfil == null)
                return NotFound("Perfil não encontrado.");

            return Ok(perfil);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Perfil>> SavePerfil([FromBody]Perfil perfil, [FromForm] IFormFile file)
        {
            if (file != null && file.Length != 0)
            {
                var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
                var database = client.GetDatabase("Testes-TCC");
                var gridFS = new GridFSBucket(database);

                using (var stream = file.OpenReadStream())
                {
                    var fileId = await gridFS.UploadFromStreamAsync(file.FileName, stream);
                    perfil.Foto_Perfil = fileId.ToString();
                }
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            perfil.Data_Atualizacao_Perfil = DateTime.Now;

            perfil.Id_Usuario = Convert.ToInt32(userId);

            await _perfilService.CreateAsync(perfil);

            return Created();
        }
    }
}
