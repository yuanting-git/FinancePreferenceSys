using FinancePreferenceSys.Models;
using Microsoft.AspNetCore.Identity;

namespace FinancePreferenceSys.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 驗證user by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User?> Authenticate(string email, string password);

        /// <summary>
        /// 註冊使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Register(RegisterViewModel model);

        /// <summary>
        /// 取得使用者By userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User?> GetUserById(string userId);

        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUser(User user);
    }
}
