using EFBase.Models.Repositories;
using EfTestBase.Models;

namespace EFBase.Models
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository _userRepository { get; }
        public IWorkingExperienceRepository _workingExperienceRepository { get; }
        Task<int> Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository _userRepository { get; }
        public IWorkingExperienceRepository _workingExperienceRepository { get; }
        private CursoDbContext _context;

        public UnitOfWork(CursoDbContext context, IUserRepository userRepository, IWorkingExperienceRepository workingExperienceRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _workingExperienceRepository = workingExperienceRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
