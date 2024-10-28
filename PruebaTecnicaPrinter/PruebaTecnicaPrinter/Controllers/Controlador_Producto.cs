using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaPrinter.Models;

namespace PruebaTecnicaPrinter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Controlador_Producto : ControllerBase
    {
        private readonly Producto[] productos = new Producto[]
        {
            new Producto { id = 1, nombre = "Jugo del Frutal", precio = 10.40m, cantidad = 6 },
            new Producto { id = 2, nombre = "Papel Scott", precio = 15.00m, cantidad = 5 },
            new Producto { id = 3, nombre = "Cereal Kellogs", precio = 20.00m, cantidad = 4 },
            new Producto { id = 4, nombre = "Coca Cola", precio = 5.00m, cantidad = 3 },
            new Producto { id = 5, nombre = "Papas Fritas", precio = 7.00m, cantidad = 2 }
        };

        [HttpGet]
        public IEnumerable<Producto> ObtenerProductos()
        {
            return productos;
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProductoPorId(int id)
        {
            var producto = productos.FirstOrDefault(p => p.id == id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }
            return producto;
        }

        [HttpPost]
        public ActionResult AgregarProductoALista(Producto nuevoProducto)
        {
            
            return Ok("Producto agregado");
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarProducto(int id, Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.id == id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            
            producto.nombre = productoActualizado.nombre;
            return Ok("Producto actualizado");
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.id == id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            
            return Ok("Producto eliminado");
        }
    }
}
