using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contexto;
using Persistencia.Interfaces;
using Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuracion de la base de datos en memoria
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseInMemoryDatabase("PruebaTecnicaDb"));

//Inyeccion de dependencias
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();

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
