using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel( AppDbContext context)    // Mi ricorda la controller dove creo il costrutore e genero il campo
        {
            this.context = context;
        }

        public IEnumerable<Curso> Cursos { get; set; }

        public async Task OnGet()
        {
            Cursos = await context.Curso.ToListAsync();
        }
    }
}
