using Vormas.Models;
namespace Vormas.Interfaces
{
    public interface ISessionService
    {
        User CurrentUser { get; }
        void SetCurrentUser(User user);
        void ClearSession();
        bool IsAuthenticated { get; }
    }
}