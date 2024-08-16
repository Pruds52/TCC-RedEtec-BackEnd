using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;
using System;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly RedEtecAPIContext _context;

    public UsuariosController(RedEtecAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuario.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id_Usuario }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id_Usuario)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuario.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuario.Any(e => e.Id_Usuario == id);
    }
}
