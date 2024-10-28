using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using MiTienda.Models;
using PruebaCuatro.Models;

namespace MiTienda.Pages.Productos
{
    using PruebaCuatro.Models;
    public class CrearModel : PageModel
    {
        [BindProperty]
        public Producto Producto { get; set; }

        public void OnGet()
        {
            // Aquí puedes inicializar datos si es necesario
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aquí puedes agregar la lógica para guardar el producto en la base de datos

            // Redirigir a otra página después de agregar el producto
            return RedirectToPage("/Index");
        }
    }
}
