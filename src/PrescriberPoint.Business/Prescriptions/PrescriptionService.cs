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

    public void AddPrescription(Prescription prescription)
    {
        if (prescription == null || string.IsNullOrEmpty(prescription.Name) || string.IsNullOrEmpty(prescription.Description))
        {
            throw new ArgumentException("Prescription cannot contain empty data");
        }

        _prescriptionRepository.Add(prescription);
    }
}