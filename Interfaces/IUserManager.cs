using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IUserManager
    {
        void Create(User e);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void UpdateUser(int userId, User e);
        void DeleteUser(int userId);
    }
}