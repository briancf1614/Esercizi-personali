using IntroAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;

        public BeerController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beer = _context.Beers.Include(b => b.Brand);


            return View(await beer.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandsId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(int a)
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandsId", "Name");
            return View();
        }



    }
}
