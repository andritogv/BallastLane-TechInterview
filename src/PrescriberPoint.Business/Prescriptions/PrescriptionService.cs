using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Prescriptions;

public class PrescriptionService : IPrescriptionService
{
    public void AddPrescription(Prescription prescription)
    {
        if (prescription == null || string.IsNullOrEmpty(prescription.Name) || string.IsNullOrEmpty(prescription.Description))
        {
            throw new ArgumentException("Prescription cannot contain empty data");

        }
    }
}