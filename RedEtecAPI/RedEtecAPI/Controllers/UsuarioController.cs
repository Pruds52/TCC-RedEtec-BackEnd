using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using System;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;  
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _usuarioService.GetAllAsync() ;
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
    public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
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
        var usuarioExiste = await _usuarioService.LoginAsync(login.Username, login.Password);

        if (usuarioExiste)
            return Ok(new { message = "Login realizado com sucesso." });

        return BadRequest(new { error = "Usuário ou senha incorreto." });
    }
}
