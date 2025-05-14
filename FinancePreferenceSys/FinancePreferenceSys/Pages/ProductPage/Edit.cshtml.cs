using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinancePreferenceSys.Data;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService service)
        {
            _productService = service;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductById(id);
            if (Product == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // ✅ 從輸入中還原原始值（將百分比轉為小數）
            Product.FeeRate = Product.FeeRate / 100;

            await _productService.UpdateProduct(Product);
            return RedirectToPage("Index");
        }
    }
}
