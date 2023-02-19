using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test1.DTOs;
using Test1.Entidades;

namespace Test1.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (pelicula.Generos is not null)
            {
                foreach (var genero in pelicula.Generos)
                {
                    context.Entry(genero).State = EntityState.Unchanged;
                }

            }
            if (pelicula.PeliculasActores is not null)
            {
                for (int i=0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].orden= i + 1;
                }
            }
            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
