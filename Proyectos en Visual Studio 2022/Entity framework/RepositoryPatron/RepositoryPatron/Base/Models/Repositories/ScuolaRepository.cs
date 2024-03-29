using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryPatron.Base.Models.Entita;

namespace RepositoryPatron.Base.Models.Repositories
{
    public interface IScuolaRepository
    {
        Task<Scuola> insert(Scuola scuola);
        Task<Scuola> GetById(int id);
    }


    public class ScuolaRepository : IScuolaRepository
    {
        private readonly SchoolDbContext _context;

        public ScuolaRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Scuola> GetById(int id)
        {
            return await _context.Scuole.Include(corso => corso.Corsi).Include(professore => professore.Professori).Include(studente => studente.Studenti).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Scuola> insert(Scuola scuola)
        {
            EntityEntry<Scuola> insertedScuola = await _context.Scuole.AddAsync(scuola);
            await _context.SaveChangesAsync();
            return insertedScuola.Entity;
        }
    }
}
