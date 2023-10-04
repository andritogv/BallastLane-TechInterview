using PrescriberPoint.Business.Repositories;
using PrescriberPoint.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Prescriptions
{
    public class PrescriptionService : IPrescriptionService
    {
        private IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<IReadOnlyList<Prescription>> GetPrescriptionsByUser(int userId)
        {
            return await _prescriptionRepository.GetAllByUser(userId);
        }

        public Task<bool> AddPrescription(Prescription prescription)
        {
            ValidatePrescription(prescription);

            return _prescriptionRepository.Add(prescription);
        }

        public Task<bool> UpdatePrescription(Prescription prescription)
        {
            ValidatePrescription(prescription);

            return _prescriptionRepository.Update(prescription);
        }

        public Task<bool> DeletePrescription(int id)
        {
            return _prescriptionRepository.Delete(id);
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
}