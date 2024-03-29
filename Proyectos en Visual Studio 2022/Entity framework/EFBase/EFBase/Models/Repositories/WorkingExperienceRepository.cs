using EfTestBase.Models;
using EfTestBase.Models.Entity;

namespace EFBase.Models.Repositories
{
    public interface IWorkingExperienceRepository
    {
        Task Insert(List<WorkingExperience> workingExperience);
    }
    public class WorkingExperienceRepository : IWorkingExperienceRepository
    {
        private readonly CursoDbContext _context;

        public WorkingExperienceRepository(CursoDbContext context)
        {
            _context = context;
        }
        public async Task Insert(List<WorkingExperience> workingExperience)
        {
            await _context.Wokringgexperience.AddRangeAsync(workingExperience);
        }
    }
}
