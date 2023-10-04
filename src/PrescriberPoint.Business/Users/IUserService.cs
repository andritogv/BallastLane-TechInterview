namespace PrescriberPoint.Business.Users
{
    public interface IUserService
    {
        void Authenticate(string username, string password);
    }
}