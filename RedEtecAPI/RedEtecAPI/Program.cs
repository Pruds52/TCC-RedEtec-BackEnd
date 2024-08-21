using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RedEtecAPIContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("RedEtecAPIContext"), new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddScoped<UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

