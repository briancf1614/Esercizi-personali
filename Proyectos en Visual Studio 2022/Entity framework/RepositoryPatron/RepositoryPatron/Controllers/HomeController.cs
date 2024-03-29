using Microsoft.AspNetCore.Mvc;
using RepositoryPatron.Base.Models.Entita;
using RepositoryPatron.Base.Models.Repositories;

namespace RepositoryPatron.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScuolaRepository _scuolaRepository;

        public HomeController(IScuolaRepository scuolaRepository)
        {
            _scuolaRepository = scuolaRepository;
        }

        [HttpGet("Hola")]
        public async Task<Scuola?> Get(int userId)
        {
            return await _scuolaRepository.GetById(userId);
        }
    }
}
