using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {

        private readonly CursoService _cursoService;
        private readonly TokenJWTController _tokenJwtController;
        private readonly UsuarioService _usuarioService;

        public CursoController(CursoService cursoService, TokenJWTController tokenJWTController, UsuarioService usuarioService)
        {
            _cursoService = cursoService;
            _tokenJwtController = tokenJWTController;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCursos()
        {
            var cursos = await _cursoService.GetAllAsync();

            return Ok(cursos);
        }

    }

}
