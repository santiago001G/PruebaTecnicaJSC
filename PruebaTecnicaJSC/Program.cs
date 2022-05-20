using Business.Business.AdminClientes;
using Business.Interfaces;
using Data.Database;
using Data.Repository.AdminCliente;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PruebaTecnicaJSC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IPruebaDatabase>(x=> new
    PruebaDatabase(builder.Configuration.GetConnectionString("PruebaTecnicaConectionString")));

#region Inyección de dependencias

builder.Services.AddTransient<IAdminClienteRepository, AdminClienteRepository>();
builder.Services.AddTransient<IAdminClientesBusiness, AdminClientesBusiness>();

#endregion

var app = builder.Build();

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
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
