using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ParteCuatro.Pages
{
    public class ProductoModel : PageModel
    {
        [BindProperty]
        [Required (ErrorMessage = "El campo ID es requerido")]
        public int id { get; set; } = 0;


        [BindProperty]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string nombre { get; set; } = "";


        [BindProperty]
        [Required(ErrorMessage = "El campo Precio es requerido")]
        public double precio { get; set; } = 0;


        [BindProperty]
        [Required(ErrorMessage = "El campo Cantidad es requerido")]
        public int cantidad { get; set; } = 0;


        public string mensajexitoso = "";
        public string mensajerror = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid) {
                mensajerror = "Validacion fallida";
                return;
            }

            mensajexitoso = " Mensaje recibido correctamente";
        }
    }
}
