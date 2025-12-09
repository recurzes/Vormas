using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class AuthManager: IAuthService
    {
        private readonly IUserManager _userManager;
        private readonly ISessionService _sessionService;

        public AuthManager(IUserManager userManager, ISessionService sessionService)
        {
            _userManager = userManager;
            _sessionService = sessionService;
        }
        
        public void RegisterUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException("Username is required");
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("Password is required");
            if (_userManager.GetUserByUsername(user.UserName) != null)
                throw new InvalidOperationException("Username already exists!");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.IsActive = true;
            
            _userManager.Create(user);
        }

        public bool LoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;
            var user = _userManager.GetUserByUsername(username);
            if (user == null) return false;

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new InvalidOperationException("User data is incomplete - PasswordHash is null");

            if (!user.IsActive)
                return false;

            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                _sessionService.SetCurrentUser(user);
                return true;
            }

            return false;
        }

        public bool ValidateUser(int userId)
        {
            var user = _userManager.GetUserById(userId);
            return user != null && user.IsActive;
        }
    }
}