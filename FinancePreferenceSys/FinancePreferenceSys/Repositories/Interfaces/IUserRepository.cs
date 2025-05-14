using FinancePreferenceSys.Models;

namespace FinancePreferenceSys.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// 檢查使用者Email是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> ChkUsrEmailExistsAsync(string email);

        /// <summary>
        /// 新增User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUserAsync(User user);

        /// <summary>
        /// 取得使用者By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUserAsync(User user);

        /// <summary>
        /// 取得使用者By userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User?> GetUserByIdAsync(string userId);
    }
}
