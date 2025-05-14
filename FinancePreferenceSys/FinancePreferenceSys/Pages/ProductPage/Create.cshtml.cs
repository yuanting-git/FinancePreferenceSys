using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateModel(IProductService service)
        {
            _productService = service;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // 將百分比轉為小數
            Product.FeeRate = Product.FeeRate / 100;

            await _productService.AddProduct(Product);
            return RedirectToPage("Index");
        }
    }
}
