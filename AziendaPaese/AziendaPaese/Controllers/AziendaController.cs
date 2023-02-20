using AutoMapper;
using AziendaPaese.DTO;
using AziendaPaese.Entita;
using Microsoft.AspNetCore.Mvc;

namespace AziendaPaese.Controllers
{
    [ApiController]
    [Route("api/Azienda")]
    public class AziendaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public AziendaController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<ActionResult> Post(AziendaCreazioneDTO aziendaCreazioneDTO)
        {
            var azienda = mapper.Map<Azienda>(aziendaCreazioneDTO);
            context.Add(azienda);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("Vari")]
        public async Task<ActionResult> Post(AziendaCreazioneDTO[] aziendeCreazioneDTO)
        {
            var aziende = mapper.Map<Azienda[]>(aziendeCreazioneDTO);
            context.AddRange(aziende);
            await context.SaveChangesAsync();
            return Ok();
        }

        
    }
}
