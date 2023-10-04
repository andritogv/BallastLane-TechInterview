namespace PrescriberPoint.Domain.Tests;

public class UserTests
{
    [Fact]
    public void TestGetSetProperties()
    {
        const int id = 1;
        const string username = "testuser";
        const string password = "testpassword";

        var user = new User
        {
            Id = id,
            Username = username,
            Password = password
        };

        Assert.Equal(id, user.Id);
        Assert.Equal(username, user.Username);
        Assert.Equal(password, user.Password);
    }
}