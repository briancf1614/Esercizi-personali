using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class CrearModel : PageModel
    {
        private readonly AppDbContext context;

        public CrearModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        public void OnGet()
        {
        }
    }
}
