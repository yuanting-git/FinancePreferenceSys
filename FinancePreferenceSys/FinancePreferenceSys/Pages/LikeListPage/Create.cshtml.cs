using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinancePreferenceSys.Data;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using System.Security.Claims;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.LikeListPage
{
    public class CreateModel : PageModel
    {
        private readonly ILikeListService _likeListService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public CreateModel(ILikeListService likeListService, IProductService productService, IUserService userService)
        {
            _likeListService = likeListService;
            _productService = productService;
            _userService = userService;
        }

        [BindProperty]
        public LikeList Input { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProduct();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userId, out var guid))
            {
                var user = await _userService.GetUserById(userId); // 你已有此方法
                if (user != null)
                {
                    Input = new LikeList
                    {
                        Account = user.Account
                    };
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var guid)) return Unauthorized();

            Input.UserID = guid;

            await _likeListService.AddLikeList(Input);
            return RedirectToPage("Index");
        }
    }

}

