using PrescriberPoint.Business.Prescriptions;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Tests;

public class PrescriptionServiceTests
{
    private readonly IPrescriptionService _sut;

    public PrescriptionServiceTests()
    {
        _sut = new PrescriptionService();
    }

    [Fact]
    public void TestAddPrescriptionShouldContainData()
    {
        var prescription = new Prescription();

        Assert.Throws<ArgumentException>(() => _sut.AddPrescription(prescription));
    }
}