using System;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class AuthManager: IAuthService
    {
        private readonly IUserManager _userManager;

        public AuthManager(IUserManager userManager)
        {
            _userManager = userManager;
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
            var user = _userManager.GetUserByUsername(username);
            if (user == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

        public bool ValidateUser(int userId)
        {
            var user = _userManager.GetUserById(userId);
            return user != null && user.IsActive;
        }
    }
}