using FinancePreferenceSys.Models;
using System.Security.Claims;
using FinancePreferenceSys.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.LikeListPage
{
    public class EditModel : PageModel
    {
        private readonly ILikeListService _likeListService;
        private readonly IProductService _productService;
        public EditModel(ILikeListService likeListService, IProductService productService)
        {
            _likeListService = likeListService;
            _productService = productService;
        }

        [BindProperty]
        public LikeList Input { get; set; }

        public List<Product> Products { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int sn)
        {
            var item = await _likeListService.GetLikeListBySN(sn);
            if (item == null) return NotFound();

            Products = await _productService.GetAllProduct();
            Input = item;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var guid)) return Unauthorized();

            Input.UserID = guid;

            await _likeListService.UpdateLikeList(Input);
            return RedirectToPage("Index");
        }
    }

}
