using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinancePreferenceSys.Pages.AccountPage
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public RegisterViewModel Register { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
                return RedirectToPage("/Index");

            Register = new RegisterViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var success = await _userService.Register(Register);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "帳號已存在");
                return Page();
            }

            return RedirectToPage("/AccountPage/Login");
        }
    }
}
