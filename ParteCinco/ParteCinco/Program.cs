using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParteCinco.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios al contenedor.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar el middleware de manejo de errores.
app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error"); // Esto redirige a una página de error personalizada.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapeo de las páginas Razor
app.MapRazorPages();

app.MapGet("/", () => Results.Redirect("/Test"));

app.Run();
