using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string ReadAllUserService()
        {
            return _userRepository.ReadAllUserRepository();
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
