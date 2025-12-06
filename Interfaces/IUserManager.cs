using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IUserManager
    {
        void Create(User e);
        List<User> GetAllUsers();
        User GetUserById();
        void UpdateUser(int userId);
        void DeleteUser(int userId);
    }
}