using FinancePreferenceSys.Models;

namespace FinancePreferenceSys.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProduct();

        /// <summary>
        /// 取得產品By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product?> GetProductById(int id);

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task AddProduct(Product product);

        /// <summary>
        /// 修改產品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task UpdateProduct(Product product);

        /// <summary>
        /// 刪除產品By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProductById(int id);
    }
}
