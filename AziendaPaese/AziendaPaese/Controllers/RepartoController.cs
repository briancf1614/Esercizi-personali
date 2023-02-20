using AutoMapper;
using AziendaPaese.DTO;
using AziendaPaese.Entita;
using Microsoft.AspNetCore.Mvc;

namespace AziendaPaese.Controllers
{
    [ApiController]
    [Route("api/Reparto")]
    public class RepartoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public RepartoController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RepartoCreazioneDTO repartoCreazioneDTO)
        {
            var reparto = mapper.Map<Reparto>(repartoCreazioneDTO);
            context.Add(reparto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
