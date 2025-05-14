using System.Data;
using FinancePreferenceSys.Data;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinancePreferenceSys.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly string _connStr;

        public ProductRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var products = new List<Product>();
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetAllProducts";
            command.CommandType = CommandType.StoredProcedure;

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    No = reader.GetInt32(reader.GetOrdinal("No")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    FeeRate = reader.GetDecimal(reader.GetOrdinal("FeeRate"))
                });
            }
            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            Product? product = null;
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetProductById";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@No", id));

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                product = new Product
                {
                    No = reader.GetInt32(reader.GetOrdinal("No")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    FeeRate = reader.GetDecimal(reader.GetOrdinal("FeeRate"))
                };
            }
            return product;
        }

        public async Task AddProductAsync(Product product)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spAddProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                command.Parameters.Add(new SqlParameter("@Price", product.Price));
                command.Parameters.Add(new SqlParameter("@FeeRate", product.FeeRate));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spUpdateProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@No", product.No));
                command.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                command.Parameters.Add(new SqlParameter("@Price", product.Price));
                command.Parameters.Add(new SqlParameter("@FeeRate", product.FeeRate));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spDeleteProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@No", id));
                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
