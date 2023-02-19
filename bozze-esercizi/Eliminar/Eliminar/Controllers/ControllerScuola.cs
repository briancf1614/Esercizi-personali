using Eliminar.DTOs;
using Eliminar.Entità;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Eliminar.Controllers
{
    [ApiController]
    [Route("Api/Scuola")]
    public class ControllerScuola:ControllerBase
    {
        private readonly AppDbContext context;

        public ControllerScuola(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ScuolaCreacionDTO scuolaCreacion)
        {
            var scuola = new Scuola
            {
                Nome = scuolaCreacion.NombreAmigo
            };
            context.Add(scuola);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    
}
