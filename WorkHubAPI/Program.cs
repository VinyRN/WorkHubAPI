using Microsoft.EntityFrameworkCore;
using WorkHub.Core.Interfaces;
using WorkHub.Core.Repositories;
using WorkHub.Core.Services;
using WorkHub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IHistoricoDeAlteracaoRepository, HistoricoDeAlteracaoRepository>();

builder.Services.AddScoped<ProjetoService>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<RelatorioService>();


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
