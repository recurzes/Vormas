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
        int UpdateUser(User e);
        int UpdatePassword(int userId, string newPasswordHash);
        int DeleteUser(int userId);
    }
}