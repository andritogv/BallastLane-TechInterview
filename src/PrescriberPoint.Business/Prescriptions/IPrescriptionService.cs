using PrescriberPoint.Domain;
using System.Collections.Generic;

namespace PrescriberPoint.Business.Prescriptions
{
    public interface IPrescriptionService
    {
        IReadOnlyList<Prescription> GetPrescriptionsByUser(int userId);

        void AddPrescription(Prescription prescription);

        void UpdatePrescription(Prescription prescription);

        void DeletePrescription(int id);
    }
}