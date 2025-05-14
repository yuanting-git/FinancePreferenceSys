using FinancePreferenceSys.Models;

namespace FinancePreferenceSys.Repositories.Interfaces
{
    public interface ILikeListRepository
    {
        /// <summary>
        /// 根據userId取得全部喜好清單
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<LikeList>> GetAllLikeListByUserIdAsync(string userId);

        /// <summary>
        /// 根據sn取得該筆喜好清單
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        Task<LikeList?> GetLikeListBySNAsync(int sn);

        /// <summary>
        /// 新增喜好清單
        /// </summary>
        /// <param name="likeList"></param>
        /// <returns></returns>
        Task AddLikeListAsync(LikeList likeList);

        /// <summary>
        /// 修改喜好清單
        /// </summary>
        /// <param name="likeList"></param>
        /// <returns></returns>
        Task UpdateLikeListAsync(LikeList likeList);

        /// <summary>
        /// 刪除喜好清單
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        Task DeleteLikeListBySNAsync(int sn);
    }
}
