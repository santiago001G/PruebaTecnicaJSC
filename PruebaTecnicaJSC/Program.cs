using Business.Business.AdminClientes;
using Business.Interfaces;
using Data.Database;
using Data.Repository.AdminCliente;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IPruebaDatabase>(x => new
    PruebaDatabase(builder.Configuration.GetConnectionString("PruebaTecnicaConectionString")));

#region Inyeccion de dependencias

builder.Services.AddTransient<IAdminClienteRepository, AdminClienteRepository>();
builder.Services.AddTransient<IAdminClientesBusiness, AdminClientesBusiness>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
