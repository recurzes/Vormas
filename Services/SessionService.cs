using Vormas.Interfaces;
using Vormas.Models;
namespace Vormas.Services
{
    public class SessionService: ISessionService
    {
        public User CurrentUser { get; private set; }
        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void ClearSession()
        {
            CurrentUser = null;
        }

        public bool IsAuthenticated => CurrentUser != null;
    }
}