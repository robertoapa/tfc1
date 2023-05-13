using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using tfc1.Models.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using tfc1.Data;
using tfc1;
using tfc1.Models.Interfaces;
using tfc1.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ILoginService, LoginService>();


var app = builder.Build();
builder.Configuration.AddJsonFile("appsettings.json");



//builder.Services.AddScoped(sp =>
//    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//// Accede a la configuración

//var Configuration = builder.Configuration;

// Configura los servicios
//builder.Services.AddHttpClient();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//// Agrega el DbContext y la conexión a la base de datos
//builder.Services.AddDbContext<Contexto>(options =>
//    options.UseSqlServer("myconnection")); // Reemplaza "NombreConnectionString" con tu cadena de conexión

//// Construye el host
//var host = builder.Build();

//await host.RunAsync();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
