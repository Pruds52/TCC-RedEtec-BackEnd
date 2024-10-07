using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly UsuarioService _usuarioService;
    private readonly IConfiguration _configuration;


    public UsuarioController(UsuarioService usuarioService, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> GetUsuarios()
    {
        return await _usuarioService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        await _usuarioService.CreateAsync(usuario);

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id_Usuario }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id_Usuario)
        {
            return BadRequest("Os IDs não são correspondentes.");
        }

        await _usuarioService.EditAsync(usuario);

        return Ok("Usuario atualizado.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        await _usuarioService.DeleteAsync(usuario);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUsuario([FromBody] Login login)
    {
        var usuario = await _usuarioService.LoginAsync(login.Username, login.Password);

        if (usuario != null)
        {
            var token = GenerateJwtToken(usuario.Id_Usuario);
            return Ok(new { token, message = "Login realizado com sucesso." });
        }

        return BadRequest(new { error = "Usuário ou senha incorreto." });
    }

    [Authorize]
    [HttpGet("user-profile")]
    public IActionResult GetUserProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Pega o ID do token JWT

        if (userId != null)
        {
            // Buscar dados do usuário pelo ID
            return Ok($"Usuário logado com ID: {userId}");
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(int userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()) // Adicionando o ID do usuário ao token
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
