using FirsMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirsMVCApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            DogViewModel doggo = new DogViewModel()
            {
                Name = "Sif",
                Age = 2
            };
            return View(doggo);
        }

        public string Hello()
        {
            return "who's there?";
        }
    }
}
