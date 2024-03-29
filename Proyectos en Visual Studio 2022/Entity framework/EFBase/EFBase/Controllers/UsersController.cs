using EFBase.Models;
using EFBase.Models.Entity;
using EFBase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace EFBase.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly InsertUser _insertUser;

        public UsersController(IUnitOfWork unitOfWork, InsertUser insertUser)
        {
            this._unitOfWork = unitOfWork;
            this._insertUser = insertUser;
        }


        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _unitOfWork._userRepository.GetAll();
        }
        [HttpGet("{userId}")]
        public async Task<User?> GetById(int userId)
        {
            return await _unitOfWork._userRepository.GetById(userId);
        }
        [HttpPost]
        public async Task<bool> Insert(int uniqueId)
        {
            return await _insertUser.Execute(uniqueId);
        }
    }
}
