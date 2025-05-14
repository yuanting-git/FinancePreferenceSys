using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Services;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService service)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _productService.DeleteProductById(id);
            return RedirectToPage("Index");
        }
    }
}
