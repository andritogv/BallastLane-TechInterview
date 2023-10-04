namespace PrescriberPoint.Domain.Tests;

public class UserTests
{
    [Fact]
    public void TestGetSetProperties()
    {
        const string username = "testuser";
        const string password = "testpassword";

        var user = new User
        {
            Username = username,
            Password = password
        };

        Assert.Equal(username, user.Username);
        Assert.Equal(password, user.Password);
    }
}