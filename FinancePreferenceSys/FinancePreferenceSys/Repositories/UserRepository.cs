using System.Data;
using FinancePreferenceSys.Models;
using FinancePreferenceSys.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinancePreferenceSys.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connStr;

        public UserRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> ChkUsrEmailExistsAsync(string email)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetUserByEmail";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Email", email));

            using var reader = await command.ExecuteReaderAsync();
            return await reader.ReadAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetUserByEmail";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Email", email));

            using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;

            return new User
            {
                UserID = reader["UserID"].ToString(),
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Account = reader["Account"].ToString()
            };
        }

        public async Task AddUserAsync(User user)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spAddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                command.Parameters.Add(new SqlParameter("@Email", user.Email));
                command.Parameters.Add(new SqlParameter("@Account", user.Account));
                command.Parameters.Add(new SqlParameter("@PasswordHash", user.PasswordHash));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using var command = connection.CreateCommand();
                command.Transaction = (SqlTransaction)transaction;
                command.CommandText = "spUpdateUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@UserID", user.UserID));
                command.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                command.Parameters.Add(new SqlParameter("@Account", user.Account));
                command.Parameters.Add(new SqlParameter("@PasswordHash", user.PasswordHash ?? (object)DBNull.Value));
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

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            await using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = "spGetUserById";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserID", userId));

            using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;

            return new User
            {
                UserID = reader["UserID"].ToString(),
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                Account = reader["Account"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString()
            };
        }
    }
}
