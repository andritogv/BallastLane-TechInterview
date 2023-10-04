using Moq;
using PrescriberPoint.Business.Prescriptions;
using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Tests;

public class PrescriptionServiceTests
{
    [Fact]
    public async Task TestGetPrescriptionsByUserShouldReturnPrescriptions()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        const int userId = 1;

        var prescriptions = new List<Prescription>
        {
            new Prescription(),
            new Prescription()
        };

        prescriptionRepositoryMock.Setup(x => x.GetAllByUser(userId)).Returns(() => Task.FromResult(prescriptions));

        var result = await sut.GetPrescriptionsByUser(userId);

        Assert.Equal(prescriptions, result);
    }

    [Fact]
    public void TestAddPrescriptionShouldContainData()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        var prescription = new Prescription();

        Assert.ThrowsAsync<ArgumentException>(() => sut.AddPrescription(prescription));
    }

    [Fact]
    public void TestAddPrescriptionShouldAddInRepository()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        var prescription = new Prescription
        {
            Name = "testname",
            Description = "testdescription"
        };

        sut.AddPrescription(prescription);

        prescriptionRepositoryMock.Verify(x => x.Add(prescription), Times.Once);
    }

    [Fact]
    public void TestUpdatePrescriptionShouldUpdateInRepository()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        var prescription = new Prescription
        {
            Id = 1,
            Name = "testname",
            Description = "testdescription"
        };

        sut.UpdatePrescription(prescription);

        prescriptionRepositoryMock.Verify(x => x.Update(prescription), Times.Once);
    }

    [Fact]
    public void TestDeletePrescriptionShouldDeleteInRepository()
    {
        var prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
        var sut = new PrescriptionService(prescriptionRepositoryMock.Object);

        const int id = 1;

        sut.DeletePrescription(id);

        prescriptionRepositoryMock.Verify(x => x.Delete(id), Times.Once);
    }
}