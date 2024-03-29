using EFBase.Models.Entity;
using EFBase.Models.Repositories;
using EFBase.Services;
using EfTestBase.Models;
using EfTestBase.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EFBase.Controllers
{
    public class TestController : Controller
    {
        //public readonly CursoDbContext _context;
        //public TestController(CursoDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IUserRepository _userRepository;
        private readonly InsertUser _insertUserWithExperiencesService;

        public TestController(IUserRepository userRepository, InsertUser insertUserWithExperiencesService)
        {
            _userRepository = userRepository;
            _insertUserWithExperiencesService = insertUserWithExperiencesService;
        }

        [HttpPost("{newId}")]
        public async Task Create(int newId)
        {
            await _insertUserWithExperiencesService.Execute(newId);
        }



        [HttpPost("test")]
        public async Task Test()
        {
            User user1 = new User()
            {
                Name = "utente2",
                Email = $"{Guid.NewGuid()}@gmail.com",
                Wokringgexperiences = new List<WorkingExperience>()
                {
                    new WorkingExperience()
                    {
                        Name = "experience 4",
                        Details = "details4",
                        Environment = "environment"
                    },
                    new WorkingExperience()
                    {
                        Name = "experience 5",
                        Details = "details5",
                        Environment = "environment"
                    }
                }
            };
            //Avendo tolto il dbcontext questo bisogna modificarlo, chiamare solo il metodo gia precostruito nella classe repositories
            //await _context.Users.AddAsync(user1);
            //await _context.SaveChangesAsync();
            await _userRepository.Insert(user1);
        }

        [HttpGet("getId")]
        public async Task<User?> Get(int userID)
        {
            //Anche qua bisogna modificarlo
            //return await _context.Users.Include(a =>a.Wokringgexperiences).FirstOrDefaultAsync(a => a.Id == userID);
            return await _userRepository.GetById(userID);
        }

    }
}
