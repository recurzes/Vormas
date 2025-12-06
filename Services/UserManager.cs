using System.Collections.Generic;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class UserManager: IUserManager
    {
        private readonly UserDbContext _repo;

        public UserManager(UserDbContext repo)
        {
            _repo = repo;
        }
        
        // Implementations
        public void Create(User e)
        {
            _repo.Create(e);
        }

        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _repo.GetUserById(userId);
        }

        public void UpdateUser(int userId, User e)
        {
            _repo.UpdateUser(userId, e);
        }

        public void DeleteUser(int userId)
        {
            _repo.DeleteUser(userId);
        }
    }
}