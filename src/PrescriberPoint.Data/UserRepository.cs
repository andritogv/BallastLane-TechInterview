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

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Add(User entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var sql = "INSERT INTO [dbo].[User] (Username, Password) VALUES (@Username, @Password)";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = entity.Username;
            command.Parameters.Add("@Password", SqlDbType.Text).Value = entity.Password;

            return await command.ExecuteNonQueryAsync();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Authenticate(string username, string password)
        {
            //var user = _users.Find(u => u.Username == username && u.Password == password);

            //return Task.FromResult(user != null);
            throw new System.NotImplementedException();
        }
    }
}