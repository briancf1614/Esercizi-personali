using Microsoft.AspNetCore.Mvc;

namespace Test1.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController:ControllerBase
    {
        private readonly AppDbContext context;

        public GenerosController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenerosController genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
