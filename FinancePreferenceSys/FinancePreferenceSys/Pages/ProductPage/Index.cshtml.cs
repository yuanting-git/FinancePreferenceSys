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
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> ProductList { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            ProductList = await _productService.GetAllProduct();
        }
    }
}
