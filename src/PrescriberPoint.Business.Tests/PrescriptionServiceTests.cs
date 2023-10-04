using Moq;
using PrescriberPoint.Business.Prescriptions;
using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Tests;

public class PrescriptionServiceTests
{
    [Fact]
    public void TestAddPrescriptionShouldContainData()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        var prescription = new Prescription();

        Assert.Throws<ArgumentException>(() => sut.AddPrescription(prescription));
    }
}