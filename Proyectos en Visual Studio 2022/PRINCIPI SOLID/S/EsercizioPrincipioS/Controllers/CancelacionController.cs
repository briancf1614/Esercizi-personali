using EsercizioPrincipioS.Business.Services;
using EsercizioPrincipioS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioPrincipioS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancelacionController : ControllerBase
    {
        private readonly ICancelacionService _cancelacionService;

        public CancelacionController(ICancelacionService cancelacionService)
        {
            _cancelacionService = cancelacionService;
        }

        [HttpPost]
        public async Task<IActionResult> CancelarSuscripcion([FromBody] Suscripcion suscripcion)
        {
            var result = await _cancelacionService.CancelarSuscripcion(suscripcion);
            return Ok(result);
        }
    }
}

