using System.Data.SqlClient;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Data.IntegrationTests;

public class UserRepositoryTests : BaseRepositoryTests
{
    public UserRepositoryTests()
    {
        // ToDo: add mechanism to prevent this from running in production
        // for testing purposes, we want to clear out the User table before each test
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        using var command = new SqlCommand("DELETE FROM [dbo].[User]", connection);
        command.ExecuteNonQuery();
    }

    [Fact]
    public async Task TestAuthenticateUser()
    {
        var sut = new UserRepository(ConnectionString);

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        await sut.Add(user);

        var result = await sut.Authenticate(user.Username, user.Password);

        Assert.True(result);
    }

    [Fact]
    public async Task TestAddUser()
    {
        var sut = new UserRepository(ConnectionString);

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        var result = await sut.Add(user);

        Assert.True(result > 0);
    }
}