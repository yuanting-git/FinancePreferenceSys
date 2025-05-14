using System.Security.Claims;
using FinancePreferenceSys.Data;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinancePreferenceSys.Pages.AccountPage
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly PasswordHasher<User> _hasher = new();

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserEditViewModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var user = await _userService.GetUserById(userId);
            if (user == null) return NotFound();

            Input = new UserEditViewModel
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Account = user.Account
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var updatedUser = new User
            {
                UserID = Input.UserID,
                UserName = Input.UserName,
                Account = Input.Account,
                PasswordHash = string.IsNullOrWhiteSpace(Input.Password)
                    ? null
                    : _hasher.HashPassword(null, Input.Password),
                ModDate = DateTime.Now
            };

            await _userService.UpdateUser(updatedUser);

            return RedirectToPage("/Index");
        }
    }
}
