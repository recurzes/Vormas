using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IAuthService
    {
        void RegisterUser(User user);
        bool LoginUser(string username, string password);
        bool ValidateUser(int userId);
    }
}