using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Prescriptions
{
    public interface IPrescriptionService
    {
        Task<IReadOnlyList<Prescription>> GetPrescriptionsByUser(int userId);

        Task<bool> AddPrescription(Prescription prescription);

        Task<bool> UpdatePrescription(Prescription prescription);

        void DeletePrescription(int id);
    }
}