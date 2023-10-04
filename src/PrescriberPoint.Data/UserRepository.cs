using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;
using System.Data.SqlClient;

namespace PrescriberPoint.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> Get(string name)
        {
            var result = new User();

            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "SELECT [Id], [Username] FROM [dbo].[User] WHERE [Username] = @Username";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = name;

            await using var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Username = reader.GetString(1);
            }

            return result;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Add(User entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "INSERT INTO [dbo].[User] (Username, Password) VALUES (@Username, @Password)";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = entity.Username;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = entity.Password;

            return await command.ExecuteNonQueryAsync();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "DELETE FROM [dbo].[User] WHERE [Id] = @Id";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "SELECT [Username] FROM [dbo].[User] WHERE [Username] = @Username AND [Password] = @Password";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

            await using var reader = await command.ExecuteReaderAsync();

            return reader.HasRows;
        }
    }
}