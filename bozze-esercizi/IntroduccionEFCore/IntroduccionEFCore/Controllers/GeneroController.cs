using AutoMapper;
using IntroduccionEFCore.DTO;
using IntroduccionEFCore.Entità;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/Generos")]
    public class GeneroController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GeneroController(AppDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(DTOGenero generoDTO)
        {
            //var genero = new Genero()
            //{
            //    Nome = generoDTO.Nome            QUESTO SI USEREBBE IN CASO DI NON USARE LA LIBRERIA AUTOMAPPER O SIMILE
            //};
            var genero = mapper.Map<Genero>(generoDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("varios")]
        public async Task<ActionResult> Post(DTOGenero[] generoDTOVarios)
        {
            var genero = mapper.Map<Genero[]>(generoDTOVarios);
            context.AddRange(genero);
            await context.SaveChangesAsync();
            return Ok();
        } 
    }
}
