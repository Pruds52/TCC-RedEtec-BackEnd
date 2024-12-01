using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using RedEtecAPI.VM;
using System.Formats.Tar;
using System.Security.Claims;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : Controller
    {
        private readonly PostagemService _postagemService;
        private readonly UsuarioService _usuarioService;
        private readonly MatriculaService _matriculaService;
        private readonly CursoService _cursoService;

        public PostagemController(PostagemService postagemService, UsuarioService usuarioService, MatriculaService matriculaService, CursoService cursoService)
        {
            _postagemService = postagemService;
            _usuarioService = usuarioService;
            _matriculaService = matriculaService;
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Postagem>>> GetPostagem()
        {
            return await _postagemService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Postagem>> GetPostagem(int id)
        {
            var postagem = await _postagemService.GetByIdAsync(id);

            if (postagem == null)
                return NotFound();

            return postagem;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Postagem>> PostPostagem([FromForm] Postagem postagem, [FromForm] IFormFile file)
        {
            if (file != null && file.Length != 0)
            {
                var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
                var database = client.GetDatabase("Testes-TCC");
                var gridFS = new GridFSBucket(database);

                using (var stream = file.OpenReadStream())
                {
                    var fileId = await gridFS.UploadFromStreamAsync(file.FileName, stream);
                    postagem.Localizacao_Midia_Postagem = fileId.ToString();
                }
            }

            postagem.Data_Postagem = DateTime.Now;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            postagem.Id_Usuario = Convert.ToInt32(userId);

            await _postagemService.CreateAsync(postagem);

            return CreatedAtAction(nameof(GetPostagem), new { id = postagem.Id_Postagem }, postagem);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutPostagem(int id, Postagem postagem)
        {
            if (id != postagem.Id_Postagem)
                return BadRequest("Os IDs não são correspondentes.");

            await _postagemService.EditAsync(postagem);

            return Ok("Postagem atualizado.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostagem(int id)
        {
            var postagem = await _postagemService.GetByIdAsync(id);

            if (postagem == null)
                return NotFound();

            await _postagemService.DeleteAsync(postagem);

            return NoContent();
        }

        [Authorize]
        [HttpGet("postagens")]
        public async Task<IActionResult> GetAllPostagens()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var matricula = await _matriculaService.GetMatriculasByUsuarioId(Convert.ToInt32(userId));

            var postagens = await _postagemService.GetAllAsync();

            var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
            var database = client.GetDatabase("Testes-TCC");
            var gridFS = new GridFSBucket(database);

            var postagemViewModels = new List<PostagemViewModels>();

            for (int i = postagens.Count - 1; i >= 0; i--)
            {
                var imageUrl = postagens[i].Localizacao_Midia_Postagem;

                var usuario = await _usuarioService.GetByIdAsync(postagens[i].Id_Usuario);

                var matriculaPostagem = await _matriculaService.GetMatriculasByUsuarioId(usuario.Id_Usuario);

                postagemViewModels.Add(new PostagemViewModels
                {
                    Id_Postagem = postagens[i].Id_Postagem,
                    Id_Usuario = postagens[i].Id_Usuario,
                    Id_Curso = matriculaPostagem.First().Id_Curso,
                    Legenda_Postagem = postagens[i].Legenda_Postagem,
                    imageUrl = imageUrl,
                    Nome_Usuario = usuario.Nome_Usuario,
                    Nivel_Acesso = usuario.Nivel_Acesso,
                    Data_Postagem = postagens[i].Data_Postagem
                });
            }

            postagemViewModels = postagemViewModels.OrderByDescending(p => p.Data_Postagem.Date).ThenByDescending(p => p.Id_Curso == matricula.First().Id_Curso).ThenByDescending(p => p.Nivel_Acesso).ToList();

            return Ok(postagemViewModels);
        }

        [HttpGet("imagem/{id}")]
        public async Task<IActionResult> GetImagem(string id)
        {
            var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
            var database = client.GetDatabase("Testes-TCC");
            var gridFS = new GridFSBucket(database);

            if (ObjectId.TryParse(id, out ObjectId objectId))
            {
                var stream = await gridFS.OpenDownloadStreamAsync(objectId);

                if (stream == null)
                {
                    return NotFound("Imagem não encontrada.");
                }

                return File(stream, "image/jpeg");
            }

            return BadRequest("ID de imagem inválido.");
        }
    }
}
