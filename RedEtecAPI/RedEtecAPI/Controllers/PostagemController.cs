using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Postagem>> PostPostagem([FromBody] Postagem postagem)
        {
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

        [HttpGet("Usuario/{usuarioId}")]
        public async Task<ActionResult> GetPostagensByUsuario(int usuarioId)
        {
            var postagens = await _postagemService.GetPostagensByUsuarioAsync(usuarioId);

            postagens = postagens.OrderBy(p => p.Data_Postagem).ToList();

            if (postagens.Count == 0)
                return NotFound();

            return Ok(postagens);
        }
    }
}
