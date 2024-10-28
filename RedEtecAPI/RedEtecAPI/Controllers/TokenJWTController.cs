using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedEtecAPI.Controllers
{
    public class TokenJWTController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioService _usuarioService;


        public TokenJWTController(IConfiguration configuration, UsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }


        [Authorize]
        [HttpGet("getperfil")]
        public ActionResult ValidarSessao()
        {
            var user = RecuperaSessao();

            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized();
        }

        public async Task<Usuario> RecuperaSessao()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

            return usuario;
        }

        public string GerarTokenJWT(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
