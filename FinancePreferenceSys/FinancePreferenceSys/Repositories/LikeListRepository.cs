using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace FinancePreferenceSys.Repositories
{
    public class LikeListRepository : ILikeListRepository
    {
        private readonly string _connStr;

        public LikeListRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<LikeList>> GetAllLikeListByUserIdAsync(string userId)
        {
            var result = new List<LikeList>();

            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetAllLikeLists";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserID", userId));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new LikeList
                {
                    SN = (int)reader["SN"],
                    OrderNum = (int)reader["OrderNum"],
                    Account = reader["Account"].ToString(),
                    TotalFee = (decimal)reader["TotalFee"],
                    TotalAmount = (decimal)reader["TotalAmount"],
                    ProductNo = (int)reader["ProductNo"],
                    UserID = Guid.Parse(reader["UserID"].ToString()),
                    ProductName = reader["ProductName"].ToString(),
                    UserEmail = reader["UserEmail"].ToString()
                });
            }

            return result;
        }

        public async Task<LikeList?> GetLikeListBySNAsync(int sn)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetLikeListById";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@SN", sn));

            using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;

            return new LikeList
            {
                SN = (int)reader["SN"],
                OrderNum = (int)reader["OrderNum"],
                Account = reader["Account"].ToString(),               
                ProductName = reader["ProductName"].ToString()
            };
        }

        public async Task AddLikeListAsync(LikeList likeList)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spAddLikeList";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@OrderNum", likeList.OrderNum));
                command.Parameters.Add(new SqlParameter("@Account", likeList.Account));
                command.Parameters.Add(new SqlParameter("@TotalFee", likeList.TotalFee));
                command.Parameters.Add(new SqlParameter("@TotalAmount", likeList.TotalAmount));
                command.Parameters.Add(new SqlParameter("@ProductNo", likeList.ProductNo));
                command.Parameters.Add(new SqlParameter("@UserID", likeList.UserID));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateLikeListAsync(LikeList likeList)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spUpdateLikeList";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@SN", likeList.SN));
                command.Parameters.Add(new SqlParameter("@OrderNum", likeList.OrderNum));
                command.Parameters.Add(new SqlParameter("@Account", likeList.Account));
                command.Parameters.Add(new SqlParameter("@TotalFee", likeList.TotalFee));
                command.Parameters.Add(new SqlParameter("@TotalAmount", likeList.TotalAmount));
                command.Parameters.Add(new SqlParameter("@ProductNo", likeList.ProductNo));
                command.Parameters.Add(new SqlParameter("@UserID", likeList.UserID));
                command.Parameters.Add(new SqlParameter("@ModDate", DateTime.Now));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteLikeListBySNAsync(int sn)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync(); 
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spDeleteLikeList";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SN", sn));

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
