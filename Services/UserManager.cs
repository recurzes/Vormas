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

        public User GetUserByUsername(string username)
        {
            return _repo.GetUserByUsername(username);
        }

        public void UpdateUser(User e)
        {
            _repo.UpdateUser(e);
        }

        public void UpdatePassword(int userId, string newPasswordHash)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            _repo.DeleteUser(userId);
        }
    }
}