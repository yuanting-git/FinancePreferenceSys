using FinancePreferenceSys.Models;

namespace FinancePreferenceSys.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProductAsync();

        /// <summary>
        /// 取得產品By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product?> GetProductByIdAsync(int id);

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task AddProductAsync(Product product);

        /// <summary>
        /// 修改產品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task UpdateProductAsync(Product product);

        /// <summary>
        /// 刪除產品By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProductByIdAsync(int id);
    }
}
