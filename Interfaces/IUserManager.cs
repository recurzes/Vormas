using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IUserManager
    {
        void Create(User e);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByUsername(string username);
        void UpdateUser(User e);
        void UpdatePassword(int userId, string newPasswordHash);
        void DeleteUser(int userId);
    }
}