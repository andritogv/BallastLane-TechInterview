namespace PrescriberPoint.Domain.Tests;

public class PrescriptionTests
{
    [Fact]
    public void TestGetSetProperties()
    {
        const int id = 1;
        const int userId = 2;
        const string name = "testprescriptionname";
        const string description = "testdescriptiondescription";

        var prescription = new Prescription
        {
            Id = id,
            UserId = userId,
            Name = name,
            Description = description,
        };

        Assert.Equal(id, prescription.Id);
        Assert.Equal(userId, prescription.UserId);
        Assert.Equal(name, prescription.Name);
        Assert.Equal(description, prescription.Description);
    }
}