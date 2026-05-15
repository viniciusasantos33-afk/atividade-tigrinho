using Microsoft.EntityFrameworkCore;
using LittleTigerV2.Data;
using LittleTigerV2.Repositories;
using LittleTigerV2.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração Banco e DI
builder.Services.AddDbContext<TigrinhoDbContext>(opt => 
    opt.UseSqlServer("Server=D06S22-1252911\\MSSQLSERVER2;Database=TigrinhoDB;User Id=sa;Password=Senai@134;TrustServerCertificate=True;"));

builder.Services.AddScoped<IApostaRepository, ApostaRepository>();
builder.Services.AddScoped<ISorteioService, SorteioService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Tigrinho}/{action=Index}/{id?}");

app.Run();