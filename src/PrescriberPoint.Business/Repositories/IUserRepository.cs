using PrescriberPoint.Domain;

namespace PrescriberPoint.Business.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Authenticate(string username, string password);
    }
}