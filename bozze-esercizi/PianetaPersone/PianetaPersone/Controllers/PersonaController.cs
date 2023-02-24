using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PianetaPersone.Entity;

namespace PianetaPersone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PersonaController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post (Persona nuevaPersona)
        {
            /* SI FA COSI IN CASO NON SI USI IL AUTOMAPPER
            var miPersona = new Persona()
            {
                Name = nuevaPersona.Name,
                Anni = nuevaPersona.Anni,
                PianetaId =nuevaPersona.PianetaId
            };*/
            
            var persona = mapper.Map<Persona>(nuevaPersona);
            context.Add(persona);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Varios")]
        public async Task<ActionResult> Post (Persona[] personas)
        {
            var muchasPersonas = mapper.Map<Persona[]>(personas);

            context.AddRange(muchasPersonas);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
