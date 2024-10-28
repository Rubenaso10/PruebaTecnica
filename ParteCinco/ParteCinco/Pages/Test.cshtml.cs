using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParteCinco.Pages
{
    public class TestModel : PageModel
    {
        public IActionResult OnGet()
        {
            throw new Exception("This is a test exception!"); // Lanzar la excepción
        }
    }
}
