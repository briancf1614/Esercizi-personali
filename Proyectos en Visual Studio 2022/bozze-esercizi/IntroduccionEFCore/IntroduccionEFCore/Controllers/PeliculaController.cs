using AutoMapper;
using IntroduccionEFCore.DTO;
using IntroduccionEFCore.Entità;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/Peliculas")]
    public class PeliculaController:ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PeliculaController(AppDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(DTOPelicula peliculaDTO)
        {
            var pelicula=mapper.Map<Pelicula>(peliculaDTO);


            /* Faccio questa parte per fare in modo che quando inserisco i generi 
             * entityframework non mi crei dei nuovi
            */
            if (pelicula.Generos is not null)
            {
                foreach (var genero in pelicula.Generos)
                {
                    /* sto dicendo con genero.state che non abbiamo fatto nessun 
                     * cambiamento(non deve inserire niente) facciamo questo perche 
                     * abbiamo fatto molti a molti saltandoci l'entita intermedia 
                     * context.Entry(genero).State = EntityState.Unchanged;
                    */
                    context.Entry(genero).State = EntityState.Unchanged;
                }

            }


            /* Qua invece che si abbiamo usato le entita intermedie facciamo solo questo*/

            if (pelicula.PeliculaActors is not null)
            {
                for (int i = 0; i < pelicula.PeliculaActors.Count; i++)
                {
                    pelicula.PeliculaActors[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
            
        }
    }
}
