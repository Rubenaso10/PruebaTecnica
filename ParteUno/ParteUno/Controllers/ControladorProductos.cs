using Microsoft.AspNetCore.Mvc;
using ParteUno.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParteUno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Leche Nido", Precio = 45.0m, CantidadStock = 10 },
            new Producto { Id = 2, Nombre = "Nescafe", Precio = 30.0m, CantidadStock = 5 },
            new Producto { Id = 3, Nombre = "Pan Bimbo", Precio = 25.0m, CantidadStock = 20 },
            new Producto { Id = 4, Nombre = "Jugo del Frutal", Precio = 15.0m, CantidadStock = 4 },
            new Producto { Id = 5, Nombre = "Mayonesa Anabelli", Precio = 35.0m, CantidadStock = 9 }
        };

        // Obtener todos los productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return productos;
        }

        // Obtener un producto por su ID
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();
            return producto;
        }

        // Agregar un nuevo producto
        [HttpPost]
        public ActionResult<Producto> AddProducto(Producto producto)
        {
            producto.Id = productos.Max(p => p.Id) + 1; // Generar un nuevo ID
            productos.Add(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // Actualizar un producto existente
        [HttpPut("{id}")]
        public ActionResult UpdateProducto(int id, Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.CantidadStock = productoActualizado.CantidadStock;
            return NoContent();
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public ActionResult DeleteProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            productos.Remove(producto);
            return NoContent();
        }
    }



}
