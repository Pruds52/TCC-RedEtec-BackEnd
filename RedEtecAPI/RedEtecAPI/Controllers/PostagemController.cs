using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : Controller
    {
        private readonly PostagemService _postagemService;

        public PostagemController(PostagemService postagemService)
        {
            _postagemService = postagemService;
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

            postagem.Id_Usuario = 7;

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

        [HttpGet("postagens")]
        public async Task<IActionResult> GetAllPostagens()
        {
            var postagens = await _postagemService.GetAllAsync();

            var client = new MongoClient("mongodb+srv://gabrielribas:051322@cluster0.4eyh8.mongodb.net/");
            var database = client.GetDatabase("Testes-TCC");
            var gridFS = new GridFSBucket(database);

            var result = new List<dynamic>();

            for (int i = postagens.Count - 1; i >= 0; i--)
            {
                var imageUrl = postagens[i].Localizacao_Midia_Postagem;

                result.Add(new
                {
                    postagens[i].Id_Postagem,
                    postagens[i].Legenda_Postagem,
                    postagens[i].Data_Postagem,
                    postagens[i].Id_Usuario,
                    imageUrl
                });
            }

            return Ok(result);
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
