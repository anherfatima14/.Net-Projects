using Dapper;
using Microsoft.Data.SqlClient;
using MyWebAPI.Models;
using System.Data;
using System.Threading.Tasks;

namespace MyWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;
        private string connectionString;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
            _dbConnection = new SqlConnection(connectionString);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            if (_dbConnection == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            string sql = @"
            INSERT INTO Users (FirstName, LastName, Dob, Gender, MobileNumber, Email, PasswordHash)
            VALUES (@FirstName, @LastName, @Dob, @Gender, @MobileNumber, @Email, @PasswordHash);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            return await _dbConnection.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (_dbConnection == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            string sql = "SELECT * FROM Users WHERE Email = @Email;";
            return await _dbConnection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
        }
    }
}
