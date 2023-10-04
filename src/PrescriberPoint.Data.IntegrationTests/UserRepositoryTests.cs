using PrescriberPoint.Domain;

namespace PrescriberPoint.Data.IntegrationTests;

public class UserRepositoryTests
{
    [Fact]
    public async Task TestAddUser()
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriberPoint;User ID=prescriberpoint;Password=prescriberpoint;Connect Timeout=60;Encrypt=False;";

        var sut = new UserRepository(connectionString);

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        var result = await sut.Add(user);

        Assert.True(result > 0);
    }
}