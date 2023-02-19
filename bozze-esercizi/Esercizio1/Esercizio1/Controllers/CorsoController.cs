using Microsoft.AspNetCore.Mvc;

namespace Esercizio1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorsoController : ControllerBase
    {
        private readonly AppDbContext context;

        public CorsoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CorsoController corso)
        {
            context.Add(corso);
            await context.SaveChangesAsync();
            return Ok();


        }
    }
}
