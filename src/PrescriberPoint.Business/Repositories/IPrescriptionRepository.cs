using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Repositories
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<IReadOnlyList<Prescription>> GetAllByUser(int userId);
    }
}