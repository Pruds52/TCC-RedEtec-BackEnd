using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using System.Security.Claims;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GrupoController : Controller
    {

        private readonly GrupoService _grupoService;
        private readonly TokenJWTController _tokenJwtController;
        private readonly UsuarioService _usuarioService;
        private readonly MatriculaService _matriculaService;
        private readonly Integrante_GrupoService _integrante_GrupoService;

        public GrupoController(GrupoService grupoService, TokenJWTController tokenJWTController, UsuarioService usuarioService, MatriculaService matriculaService, Integrante_GrupoService integrante_GrupoService)
        {
            _grupoService = grupoService;
            _tokenJwtController = tokenJWTController;
            _usuarioService = usuarioService;
            _matriculaService = matriculaService;
            _integrante_GrupoService = integrante_GrupoService;
        }

        [HttpGet("getgrupo/{id}")]
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

                return CreatedAtAction(nameof(GetGrupoById), new { id = grupo.Id_Grupo }, grupo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("curso")]
        public async Task<ActionResult> GetGrupoByCurso()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var matricula = await _matriculaService.GetMatriculasByUsuarioId(Convert.ToInt32(userId));

            var grupo = await _grupoService.GetGrupoByNome(matricula.First().Curso.Nome_Curso);

            return Ok(grupo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetIntegrantesGrupoByGrupoId(int id)
        {
            var integrantes = await _integrante_GrupoService.GetIntegrantesByGrupoId(id);

            return Ok(integrantes);
        }
    }
}
