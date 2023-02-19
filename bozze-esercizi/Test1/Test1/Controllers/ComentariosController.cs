using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test1.DTOs;
using Test1.Entidades;

namespace Test1.Controllers
{
    [ApiController]
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    public class ComentariosController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ComentariosController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int peliculaId, ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId = peliculaId;
            context.Add(comentario);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
