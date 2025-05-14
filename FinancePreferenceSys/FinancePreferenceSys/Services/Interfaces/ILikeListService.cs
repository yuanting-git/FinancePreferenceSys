using FinancePreferenceSys.Models;

namespace FinancePreferenceSys.Services.Interfaces
{
    public interface ILikeListService
    {
        /// <summary>
        /// 根據userId取得所有喜好清單
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<LikeList>> GetAllLikeListByUserId(string userId);

        /// <summary>
        /// 根據SN取得喜好清單
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        Task<LikeList?> GetLikeListBySN(int sn);

        /// <summary>
        /// 新增喜好清單
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddLikeList(LikeList item);

        /// <summary>
        /// 修改喜好清單
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateLikeList(LikeList item);

        /// <summary>
        /// 刪除喜好清單By SN
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        Task DeleteLikeListBySN(int sn);
    }
}
