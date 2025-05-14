using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinancePreferenceSys.Pages.LikeListPage
{
    public class DeleteModel : PageModel
    {
        private readonly ILikeListService _likeListService;
        public DeleteModel(ILikeListService likeListService)
        {
            _likeListService = likeListService;
        }

        [BindProperty]
        public LikeList Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int sn)
        {
            var item = await _likeListService.GetLikeListBySN(sn);
            if (item == null) return NotFound();

            Item = item;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Item == null || Item.SN == 0) return NotFound();

            await _likeListService.DeleteLikeListBySN(Item.SN);
            return RedirectToPage("Index");
        }
    }
}
