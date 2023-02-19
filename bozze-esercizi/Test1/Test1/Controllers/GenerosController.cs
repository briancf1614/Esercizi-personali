using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test1.DTOs;
using Test1.Entidades;

namespace Test1.Controllers
{
    [ApiController]
    [Route("api/generos")]      //Si stabilisce aggiustamenti della conessione
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GenerosController(AppDbContext context, IMapper mapper)      //creo un costruttore e aggiungo allinterno un context di tipo (classeContext)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        //creo il metodo e aggiungo la classe che vorrò usare oppure un DTO(se non usi un DTO si vedranno tutti i campi nell'API)
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion) //scrivo async(consigliato quando si eegue una operazione IO sistema con sistema)
        {
            var genero = mapper.Map<Genero>(generoCreacion);
            context.Add(genero);                    //Serve per segnalare loggetto che salvero avanti
            await context.SaveChangesAsync();       //Serve per salvare tutti i cambiamenti che ho fatto (uso anche await)
            return Ok();
        }

        [HttpPost("varios")]

        public  async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacionDTO)
        {
            var generos = mapper.Map<Genero[]>(generosCreacionDTO);
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
