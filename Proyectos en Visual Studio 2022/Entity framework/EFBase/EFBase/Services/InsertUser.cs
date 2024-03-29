using EFBase.Models;
using EFBase.Models.Entity;
using EfTestBase.Models.Entity;

namespace EFBase.Services
{
    public class InsertUser
    {
        private readonly IUnitOfWork _unitWork;

        public InsertUser(IUnitOfWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task<bool> Execute(int id)
        {
            User user = new User()
            {
                Name = $"id-{id}",
                Email = "Transazione@hotmail.com",
            };
            
            List<WorkingExperience> workingExperiences = new List<WorkingExperience>()
            {
                new WorkingExperience()
                {
                    User = user,
                    Name = user.Id.ToString(),
                    Details = "details1",
                    Environment = "environment"
                },
                new WorkingExperience()
                {
                    User = user,
                    Name = user.Id.ToString(),
                    Details = "details2",
                    Environment = "environment"
                }
            };

            await _unitWork._userRepository.Insert(user);
            await _unitWork._workingExperienceRepository.Insert(workingExperiences);
            await _unitWork.Save();
            return true;
        }
    }
}
