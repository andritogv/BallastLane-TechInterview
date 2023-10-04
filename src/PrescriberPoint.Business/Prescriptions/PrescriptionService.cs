using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Prescriptions;

public class PrescriptionService : IPrescriptionService
{
    private IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    public IReadOnlyList<Prescription> GetPrescriptionsByUser(int userId)
    {
        return _prescriptionRepository.GetAllByUser(userId);
    }

    public void AddPrescription(Prescription prescription)
    {
        ValidatePrescription(prescription);

        _prescriptionRepository.Add(prescription);
    }

    public void UpdatePrescription(Prescription prescription)
    {
        ValidatePrescription(prescription);

        _prescriptionRepository.Update(prescription);
    }

    public void DeletePrescription(int id)
    {
        _prescriptionRepository.Delete(id);
    }

    private void ValidatePrescription(Prescription prescription)
    {
        if (prescription == null || string.IsNullOrEmpty(prescription.Name) ||
            string.IsNullOrEmpty(prescription.Description))
        {
            throw new ArgumentException("Prescription cannot contain empty data");
        }
    }
}