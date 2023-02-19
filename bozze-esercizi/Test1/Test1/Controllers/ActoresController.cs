using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test1.DTOs;
using Test1.Entidades;

namespace Test1.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController:ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ActoresController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
