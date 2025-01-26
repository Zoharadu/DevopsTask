using Common;
using Repository.Interface;
using Service.Interface;

namespace Service.ImpI
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUserService(string id, string name, string mail)
        {
            _userRepository.CreateUserRepository(id, name, mail);
        }
        public async Task<IEnumerable<UserModel>> ReadAllUserRepository()
        {
            return await _userRepository.ReadAllUserRepository();
        }
        public object ReadUserService(string id)
        {
            return _userRepository.ReadUserRepository(id);
        }
        public string UpdateUserService(string id, string? name, string? mail)
        {
            return _userRepository.UpdateUserRepository(id, name, mail);
        }
        public string DeleteUserService(string id)
        {
            return _userRepository.DeleteUserRepository(id);
        }
    }
}
