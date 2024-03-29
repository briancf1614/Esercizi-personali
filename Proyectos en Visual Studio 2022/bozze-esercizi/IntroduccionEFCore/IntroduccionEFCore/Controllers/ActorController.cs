using AutoMapper;
using IntroduccionEFCore.DTO;
using IntroduccionEFCore.Entità;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/Actors")]
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ActorController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(DTOActor actorDTO)
        {
            var actor = mapper.Map<Actor>(actorDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Varios")]

        public async Task<ActionResult> Post(DTOActor[] actoresDTO)
        {
            var actores = mapper.Map<Actor[]>(actoresDTO);
            context.AddRange(actores);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
