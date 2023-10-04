namespace PrescriberPoint.Domain.Tests;

public class PrescriptionTests
{
    [Fact]
    public void TestGetSetProperties()
    {
        const int id = 1;
        const string name = "testprescriptionname";
        const string description = "testdescriptiondescription";
        const int userId = 1;

        var prescription = new Prescription
        {
            Id = id,
            Name = name,
            Description = description,
            UserId = userId
        };

        Assert.Equal(id, prescription.Id);
        Assert.Equal(name, prescription.Name);
        Assert.Equal(description, prescription.Description);
        Assert.Equal(userId, prescription.UserId);
    }
}