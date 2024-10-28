using Microsoft.EntityFrameworkCore;
using ParteTres;
using ParteTres.Models;

using (var context = new AppDbContext())
{
    // Agregar un nuevo cliente y una orden
    var cliente = new Cliente { Nombre = "Luis Zepeda" };
    context.Clientes.Add(cliente);
    await context.SaveChangesAsync();

    var orden = new Orden { Fecha = DateTime.Now, Total = 150.00m, ClienteId = cliente.ClienteId };
    context.Ordenes.Add(orden);
    await context.SaveChangesAsync();

    // Obtener el total de las órdenes para un cliente específico
    var totalOrdenes = await context.Ordenes
        .Where(o => o.ClienteId == cliente.ClienteId)
        .SumAsync(o => o.Total);

    Console.WriteLine($"Total de órdenes para el cliente {cliente.Nombre}: {totalOrdenes}");
}


