using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RedEtecAPI.Controllers;
using RedEtecAPI.Data;
using RedEtecAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RedEtecAPIContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("RedEtecAPIContext"), new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PostagemService>();
builder.Services.AddScoped<Mensagem_PrivadaService>();
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<TokenJWTController>();
builder.Services.AddScoped<PerfilService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<MatriculaService>();
builder.Services.AddScoped<Integrante_GrupoService>();
builder.Services.AddScoped<Mensagem_GrupoService>();
builder.Services.AddScoped<AnexoService>();
builder.Services.AddScoped<Mensagem_CensuradaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseStaticFiles(); // Habilita arquivos estáticos

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Mapeia as rotas dos controladores

app.Run();
