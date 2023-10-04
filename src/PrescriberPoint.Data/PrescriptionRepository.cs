using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrescriberPoint.Data
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly string _connectionString;

        public PrescriptionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Prescription> Get(string name)
        {
            var result = new Prescription();

            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "SELECT [Id], [UserId], [Name], [Description] FROM [dbo].[Prescription] WHERE [Name] = @Name";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;

            await using var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.UserId = reader.GetInt32(1);
                result.Name = reader.GetString(2);
                result.Description = reader.GetString(3);
            }

            return result;
        }

        public Task<IEnumerable<Prescription>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Add(Prescription entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "INSERT INTO [dbo].[Prescription] (UserId, Name, Description) VALUES (@UserId, @Name, @Description)";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@UserId", SqlDbType.Int).Value = entity.UserId;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
            command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;

            return await command.ExecuteNonQueryAsync();
        }

        public void Update(Prescription entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Prescription>> GetAllByUser(int userId)
        {
            var result = new List<Prescription>();

            await using var connection = new SqlConnection(_connectionString);
            connection.Open();

            const string sql = "SELECT [Id], [UserId], [Name], [Description] FROM [dbo].[Prescription] WHERE [UserId] = @UserId";

            await using var command = new SqlCommand(sql, connection);

            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userId;

            await using var reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                result.Add(new Prescription
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Description = reader.GetString(3)
                });
            }

            return result;        }
    }
}