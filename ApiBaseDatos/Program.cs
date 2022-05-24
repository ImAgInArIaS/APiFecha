using System.Runtime.CompilerServices;
using ApiBaseDatos.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Prog31105Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));

builder.Services.AddCors();
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EneableLegacyTimestamBehavior",true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors(c=>{
     c.AllowAnyHeader();
 c.AllowAnyMethod();
 c.AllowAnyOrigin();
 });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
