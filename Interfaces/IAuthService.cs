using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IAuthService
    {
        void RegisterUser(User e);
        bool LoginUser(string username, string password);
        bool ValidateUser(int userId);
    }
}