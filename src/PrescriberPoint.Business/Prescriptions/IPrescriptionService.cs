using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Prescriptions;

public interface IPrescriptionService
{
    void AddPrescription(Prescription prescription);
}