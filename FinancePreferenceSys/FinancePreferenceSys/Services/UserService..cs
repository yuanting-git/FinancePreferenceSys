using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using FinancePreferenceSys.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinancePreferenceSys.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }        

        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null) return null;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            return result == PasswordVerificationResult.Failed ? null : user;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            if (await _userRepository.ChkUsrEmailExistsAsync(model.Email)) return false;

            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Account = model.Account,
            };
            user.PasswordHash = hasher.HashPassword(user, model.Password);

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<User?> GetUserById(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
