using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GrupoController : Controller
    {

        private readonly GrupoService _grupoService;
        private readonly TokenJWTController _tokenJwtController;
        private readonly UsuarioService _usuarioService;

        public GrupoController(GrupoService grupoService, TokenJWTController tokenJWTController, UsuarioService usuarioService)
        {
            _grupoService = grupoService;
            _tokenJwtController = tokenJWTController;
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetGrupoById(int id)
        {
            var grupo = await _grupoService.GetByIdAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        [HttpPost]
        public async Task<ActionResult<Grupo>> CriarGrupo(Grupo grupo)
        {
            try
            {
                await _grupoService.CreateAsync(grupo);

                return CreatedAtAction(nameof(GetGrupoById), new { id = grupo.Id_Grupo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
