using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using FinancePreferenceSys.Services.Interfaces;

namespace FinancePreferenceSys.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<List<Product>> GetAllProduct() => _productRepo.GetAllProductAsync();
        public Task<Product?> GetProductById(int id) => _productRepo.GetProductByIdAsync(id);
        public Task AddProduct(Product product) => _productRepo.AddProductAsync(product);
        public Task UpdateProduct(Product product) => _productRepo.UpdateProductAsync(product);
        public Task DeleteProductById(int id) => _productRepo.DeleteProductByIdAsync(id);
    }
}
