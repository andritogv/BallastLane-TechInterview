using PrescriberPoint.Business.Repositories;

namespace PrescriberPoint.Business.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Authenticate(string username, string password)
        {
            _userRepository.Authenticate(username, password);
        }
    }
}