using Microsoft.EntityFrameworkCore;
using RedEtecAPI.Data;
using RedEtecAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RedEtecAPIContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("RedEtecAPIContext"), new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddScoped<UsuarioService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
