using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Repositories;

public interface IPrescriptionRepository : IRepository<Prescription>
{
    IReadOnlyList<Prescription> GetAllByUser(int userId);
}