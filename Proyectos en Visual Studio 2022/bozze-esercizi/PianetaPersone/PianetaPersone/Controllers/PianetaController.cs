using Microsoft.AspNetCore.Mvc;
using PianetaPersone.Entity;

namespace PianetaPersone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PianetaController : ControllerBase
    {
        private readonly AppDbContext context;

        public PianetaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pianeta pianetaController)
        {
            var ilMioPianeta = new Pianeta()
            {
                Nome = pianetaController.Nome,
                Descrizione = pianetaController.Descrizione
            };
            context.Add(ilMioPianeta);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
