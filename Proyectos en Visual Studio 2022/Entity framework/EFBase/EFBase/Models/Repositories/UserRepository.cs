using EFBase.Models.Entity;
using EfTestBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFBase.Models.Repositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User user);
        Task<User?> GetById(int id);
        Task<List<User>> GetAll();
    }
    public class UserRepository : IUserRepository
    {
        private readonly CursoDbContext _context;

        public UserRepository(CursoDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.Include(a =>a.Wokringgexperiences).FirstOrDefaultAsync(a=>a.Id == id);
        }

        public async Task<User> Insert(User user)
        {
            EntityEntry<User> insertedUser = await _context.Users.AddAsync(user);
            //usare il Unit of work, no es mas necesario hacer el guardado aqui lo haremos en el unit of work junto a las otras tablas, concepto de 
                //TRANSACTION
            //await _context.SaveChangesAsync();
            return insertedUser.Entity;
        }

        public async Task<List<User>> GovernmentUser()
        {
            return await _context.Users.Include(a=>a.Wokringgexperiences.Where(w=>w.Name == "Government")).ToListAsync();
        }

        public Task<List<User>> GetAll()
        {
            return _context.Users.ToListAsync();
        }
    }
}
