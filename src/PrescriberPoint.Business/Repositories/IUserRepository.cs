using System.Threading.Tasks;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> Authenticate(string username, string password);
    }
}