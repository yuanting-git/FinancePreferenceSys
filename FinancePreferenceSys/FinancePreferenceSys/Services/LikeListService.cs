using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Services
{
    public class LikeListService: ILikeListService
    {
        private readonly ILikeListRepository _likeListRepo;
        public LikeListService(ILikeListRepository likeListRepo)
        {
            _likeListRepo = likeListRepo;
        }

        public Task<List<LikeList>> GetAllLikeListByUserId(string userId) => _likeListRepo.GetAllLikeListByUserIdAsync(userId);
        public Task<LikeList?> GetLikeListBySN(int sn) => _likeListRepo.GetLikeListBySNAsync(sn);
        public Task AddLikeList(LikeList item) => _likeListRepo.AddLikeListAsync(item);
        public Task UpdateLikeList(LikeList item) => _likeListRepo.UpdateLikeListAsync(item);
        public Task DeleteLikeListBySN(int sn) => _likeListRepo.DeleteLikeListBySNAsync(sn);
    }
}
