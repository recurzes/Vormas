using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class UserManager: IUserManager
    {
        private readonly IUserManager _repo;

        public UserManager(IUserManager repo)
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
            throw new System.NotImplementedException();
        }

        public User GetUserById()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}