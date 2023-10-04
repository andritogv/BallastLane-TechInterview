using PrescriberPoint.Domain;
using System.Collections.Generic;

namespace PrescriberPoint.Business.Repositories
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IReadOnlyList<Prescription> GetAllByUser(int userId);
    }
}