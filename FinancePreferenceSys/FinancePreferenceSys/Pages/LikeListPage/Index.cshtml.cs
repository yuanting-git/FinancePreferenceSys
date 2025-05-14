using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using System.Security.Claims;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.LikeListPage
{
    public class IndexModel : PageModel
    {
        private readonly ILikeListService _likeListService;

        public IndexModel(ILikeListService likeListService)
        {
            _likeListService = likeListService;
        }
        public List<LikeList> LikeLists { get; set; } = new List<LikeList>();

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId)) 
            {
                LikeLists = await _likeListService.GetAllLikeListByUserId(userId);
            }
        }

    }
}
