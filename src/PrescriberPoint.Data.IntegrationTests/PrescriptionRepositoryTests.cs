using System.Data.SqlClient;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Data.IntegrationTests;

public class PrescriptionRepositoryTests : BaseRepositoryTests
{
    public PrescriptionRepositoryTests()
    {
        // ToDo: add mechanism to prevent this from running in production
        // for testing purposes, we want to clear out the User and Prescription tables before each test
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        using var prescriptionCommand = new SqlCommand("DELETE FROM [dbo].[Prescription]", connection);
        prescriptionCommand.ExecuteNonQuery();
        using var userCommand = new SqlCommand("DELETE FROM [dbo].[User]", connection);
        userCommand.ExecuteNonQuery();
    }

    [Fact]
    public async Task TestAddPrescription()
    {
        var userRepository = new UserRepository(ConnectionString);
        var sut = new PrescriptionRepository(ConnectionString);

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        _ = await userRepository.Add(user);
        user = await userRepository.Get(user.Username);

        var prescription = new Prescription
        {
            UserId = user.Id,
            Name = "testprescription",
            Description = "testdescription"
        };

        var result = await sut.Add(prescription);

        Assert.True(result > 0);
    }

    [Fact]
    public async Task TestGetPrescription()
    {
        var userRepository = new UserRepository(ConnectionString);
        var sut = new PrescriptionRepository(ConnectionString);

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        _ = await userRepository.Add(user);
        user = await userRepository.Get(user.Username);

        var prescription = new Prescription
        {
            UserId = user.Id,
            Name = "testprescription",
            Description = "testdescription"
        };

        _ = await sut.Add(prescription);
        var result = await sut.Get(prescription.Name);

        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal(user.Id, result.UserId);
        Assert.Equal(prescription.Name, result.Name);
        Assert.Equal(prescription.Description, result.Description);
    }
}