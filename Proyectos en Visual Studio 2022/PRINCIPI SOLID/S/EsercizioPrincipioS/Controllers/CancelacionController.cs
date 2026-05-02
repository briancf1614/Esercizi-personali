using EsercizioPrincipioS.Domain;
using EsercizioPrincipioS.Domain.Interfaces;
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
            try
            {
                var result = await _cancelacionService.CancelarSuscripcion(suscripcion);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

