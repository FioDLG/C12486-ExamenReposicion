using Microsoft.EntityFrameworkCore;
using GestorDeApartamentos.DA;
using GestorDeApartamentos.BL;


var builder = WebApplication.CreateBuilder(args);

// Configurar EF Core con SQL Server
builder.Services.AddDbContext<ExamenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<ApartamentosRepository>();
builder.Services.AddScoped<ApartamentosService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Apartamentos}/{action=Index}/{id?}");

app.Run();

