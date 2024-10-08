using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using RedEtecAPI.Controllers;
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
    private readonly TokenJWTController _tokenJWTController;

    public UsuarioController(UsuarioService usuarioService, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
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
            var token = _tokenJWTController.GerarTokenJWT(usuario.Id_Usuario);
            return Ok(new { token, message = "Login realizado com sucesso." });
        }

        return BadRequest(new { error = "Usuário ou senha incorreto." });
    }

    [Authorize]
    [HttpGet("getcontatos")]
    public async Task<ActionResult> GetContatos()
    {
        var usuarioLogado = await _tokenJWTController.RecuperaSessao();

        var contatos = await _usuarioService.GetContatos(usuarioLogado.Id_Usuario);

        if (contatos.Count != 0)
            return Ok(contatos);

        return NoContent();
    }

}
