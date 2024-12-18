﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using RedEtecAPI.Controllers;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;
using RedEtecAPI.VM;
using System.Collections.Frozen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly UsuarioService _usuarioService;
    private readonly TokenJWTController _tokenJWTController;
    private readonly MatriculaService _matriculaService;
    private readonly CursoService _cursoService;

    public UsuarioController(UsuarioService usuarioService, TokenJWTController tokenJWTController, MatriculaService matriculaService, CursoService cursoService)
    {
        _usuarioService = usuarioService;
        _tokenJWTController = tokenJWTController;
        _matriculaService = matriculaService;
        _cursoService = cursoService; 
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
    public async Task<ActionResult<Usuario>> PostUsuario(UsuarioViewModels usuarioViewModels)
    {
        var usuario = new Usuario
        {
            Nome_Usuario = usuarioViewModels.Nome_Usuario,
            CPF_Usuario = usuarioViewModels.CPF_Usuario,
            Data_Nascimento_Usuario = usuarioViewModels.Data_Nascimento_Usuario,
            Email_Usuario = usuarioViewModels.Email_Usuario,
            Senha_Usuario = usuarioViewModels.Senha_Usuario,
            Nivel_Acesso = usuarioViewModels.Nivel_Acesso,
        };

        await _usuarioService.CreateAsync(usuario);

        var matricula = new Matricula
        {
            Id_Usuario = usuario.Id_Usuario,
            Id_Curso = usuarioViewModels.Id_Curso
        };

        await _matriculaService.CreateAsync(matricula);

        return CreatedAtAction(nameof(GetUsuario), new { id = usuarioViewModels.Id_Usuario } , usuarioViewModels);
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
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

        var contatos = await _usuarioService.GetContatos(usuario.Id_Usuario);

        if (contatos.Count != 0)
            return Ok(contatos);

        return NoContent();
    }

    [Authorize]
    [HttpGet("getusuario")]
    public async Task<ActionResult> GetUsuarioByToken()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuario = await _usuarioService.GetByIdAsync(Convert.ToInt32(userId));

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [Authorize]
    [HttpGet("cursos")]
    public async Task<ActionResult> GetCursosByUsuarioLogado()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var matricula = await _matriculaService.GetMatriculasByUsuarioId(Convert.ToInt32(userId));

        var cursos = new List<Curso>();

        foreach (var curso in matricula) 
            cursos.Add(curso.Curso);

        return Ok(cursos);
    }
}
