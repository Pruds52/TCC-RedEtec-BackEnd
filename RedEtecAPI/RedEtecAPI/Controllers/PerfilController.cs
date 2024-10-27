using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var perfil = await _perfilService.GetPerfilByUsuarioId(Convert.ToInt32(userId));

            if (perfil == null)
                return NotFound("Perfil não encontrado.");

            return Ok(perfil);
        }
    }
}
