using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Prescriptions
{
    public interface IPrescriptionService
    {
        Task<Prescription> GetPrescription(int id);

        Task<IReadOnlyList<Prescription>> GetPrescriptionsByUser(int userId);

        Task<bool> AddPrescription(Prescription prescription);

        Task<bool> UpdatePrescription(Prescription prescription);

        Task<bool> DeletePrescription(int id);
    }
}